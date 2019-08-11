using System;
using System.Buffers.Text;
using System.Runtime.InteropServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Base64Benchmarking
{
    internal class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run<GuidExtensionsBenchmarks>();
        }
    }

    [MemoryDiagnoser]
    public class GuidExtensionsBenchmarks
    {
        private Guid _guid;

        [GlobalSetup]
        public void Setup() => _guid = Guid.NewGuid();

        [Benchmark(Baseline = true)]
        public string Base64EncodedGuidOriginal() => _guid.EncodeBase64StringOriginal();

        [Benchmark(Baseline = false)]
        public string Base64EncodedGuidEfficient() => _guid.EncodeBase64String();

        [Benchmark(Baseline = false)]
        public string Base64EncodedGuidEvenMoreEfficient() => _guid.EncodeBase64StringMoreEfficient();
    }

    public static class GuidExtensions
    {
        public static string EncodeBase64StringOriginal(this Guid guid)
        {
            return Convert.ToBase64String(guid.ToByteArray())
                .Replace("/", "-").Replace("+", "-").Replace("=", string.Empty);
        }
    }

    public static class EfficientGuidExtensions
    {
        private const byte ForwardSlashByte = (byte) '/';
        private const byte DashByte = (byte) '-';
        private const byte PlusByte = (byte) '+';
        private const byte UnderscoreByte = (byte) '_';

        public static string EncodeBase64String(this Guid guid)
        {
            // allocate two byte arrays (use Span<T> to avoid object creation on heap),
            // also avoids garbage collection runs for these Gen-0 objects
            Span<byte> guidBytes = stackalloc byte[16];
            Span<byte> encodedBytes = stackalloc byte[24];

            // write bytes from the Guid - GUID is a 128-bit integer which occupies 16 bytes.
            // That’s why stack allocated a byte array of 16 elements for this method to write those bytes into.
            MemoryMarshal.TryWrite(guidBytes, ref guid);

            // encode the binary bytes for the Guid into UTF-8 encoded text, represented as Base64
            Base64.EncodeToUtf8(guidBytes, encodedBytes, out _, out _);

            // replace any characters which are not URL safe
            for (var i = 0; i < 22; i++)
            {
                if (encodedBytes[i] == ForwardSlashByte)
                    encodedBytes[i] = DashByte;

                if (encodedBytes[i] == PlusByte)
                    encodedBytes[i] = UnderscoreByte;
            }

            // skip the last two bytes as these will be "==" padding
            var final = Encoding.UTF8.GetString(encodedBytes.Slice(0, 22));

            return final;
        }
    }

    public static class EvenMoreEfficientGuidExtensions
    {
        private const byte ForwardSlashByte = (byte) '/';
        private const char Dash = '-';
        private const byte PlusByte = (byte) '+';
        private const char Underscore = '_';

        public static string EncodeBase64StringMoreEfficient(this Guid guid)
        {
            Span<byte> guidBytes = stackalloc byte[16];
            Span<byte> encodedBytes = stackalloc byte[24];

            MemoryMarshal.TryWrite(guidBytes, ref guid);
            Base64.EncodeToUtf8(guidBytes, encodedBytes, out _, out _);

            Span<char> chars = stackalloc char[22];

            for (var i = 0; i < 22; i++)
            {
                switch (encodedBytes[i])
                {
                    case ForwardSlashByte:
                        chars[i] = Dash;
                        break;
                    case PlusByte:
                        chars[i] = Underscore;
                        break;
                    default:
                        chars[i] = (char) encodedBytes[i];
                        break;
                }
            }

            return new string(chars);
        }
    }
}