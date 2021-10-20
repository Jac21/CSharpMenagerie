using PatternMatching.Core;
using static System.Console;

namespace PatternMatching
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Hello, Pattern Matcher!");

            ImageMacro image = new Lolcat("I made you a cookie");

            Pattern.Match(image)
                .Case<Lolcat, string>(c => WriteLine($"Lolcat says '{c}'"))
                .Case<Lolrus, int>(b => WriteLine($"I has {b} buckets"))
                .Case<ORlyOwl>(() => WriteLine("O RLY?"));
        }
    }

    internal abstract class ImageMacro
    {
    }

    internal class Lolcat : ImageMacro, IMatchable<string>
    {
        public string Caption;

        public Lolcat(string caption)
        {
            Caption = caption;
        }

        public string GetArg()
        {
            return Caption;
        }
    }

    internal class Lolrus : ImageMacro, IMatchable<int>
    {
        public int Buckets;

        public Lolrus(int buckets)
        {
            Buckets = buckets;
        }

        public int GetArg()
        {
            return Buckets;
        }
    }

    internal class ORlyOwl : ImageMacro
    {
    }
}