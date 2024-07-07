// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Hello, Hashing!");

Console.WriteLine($"Hashing with {nameof(Sha512HashingUtilities)}!");

var (hash, code) = Sha512HashingUtilities.ToHashedCodeV1("password");

Console.WriteLine(
    $"Result from calling {nameof(Sha512HashingUtilities.ToHashedCodeV1)} with 'password' - {code}");

Console.WriteLine(
    $"Result from calling {nameof(Sha512HashingUtilities.VerifyCodeV1)} with 'password' - {Sha512HashingUtilities.VerifyCodeV1("password", code)}");

Console.WriteLine(
    $"Result from calling {nameof(Sha512HashingUtilities.ToHashedCodeV2)} with 'password' - {await Sha512HashingUtilities.ToHashedCodeV2("password")}");
//
// Console.WriteLine(
//     $"Result from calling {nameof(Sha512HashingUtilities.VerifyCodeV2)} with 'password' - {await Sha512HashingUtilities.VerifyCodeV2("password", "password")}");

var rfc2898DeriveBytesHashingUtilities = new Rfc2898DeriveBytesHashingUtilities();

var hashedCode = rfc2898DeriveBytesHashingUtilities.ToHashedCode("password", "jac21");

Console.WriteLine(
    $"Result from calling {nameof(Rfc2898DeriveBytesHashingUtilities.ToHashedCode)} with 'password' - {hashedCode}");

Console.WriteLine(
    $"Result from calling {nameof(Rfc2898DeriveBytesHashingUtilities.VerifyCode)} with 'password' - {rfc2898DeriveBytesHashingUtilities.VerifyCode("password", "jac21", hashedCode)}");

Console.WriteLine("fin");
Console.ReadLine();

public static class Sha512HashingUtilities
{
    /// <summary>
    /// Using SHA512
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static (byte[] hash, string) ToHashedCodeV1(string code)
    {
        using var sha512 = SHA512.Create();

        var bytes = Encoding.UTF8.GetBytes(code);
        var hash = sha512.ComputeHash(bytes);

        return (hash, Convert.ToBase64String(hash));
    }

    /// <summary>
    /// Using SHA512
    /// </summary>
    /// <param name="code"></param>
    /// <param name="storedCode"></param>
    /// <returns></returns>
    public static bool VerifyCodeV1(string code, string storedCode)
    {
        var (hash, _) = ToHashedCodeV1(code);

        var storedHash = Convert.FromBase64String(storedCode);

        return CryptographicOperations.FixedTimeEquals(hash, storedHash);
    }

    /// <summary>
    /// Using SHA512
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static async Task<string> ToHashedCodeV2(string code)
    {
        var bytes = Encoding.ASCII.GetBytes(code);
        var hash = await SHA512.HashDataAsync(new MemoryStream(bytes));

        return Convert.ToHexString(hash);
    }

    /// <summary>
    /// Using SHA512
    /// </summary>
    /// <param name="code"></param>
    /// <param name="storedCode"></param>
    /// <returns></returns>
    public static async Task<bool> VerifyCodeV2(string code, string storedCode)
    {
        var storedHash = Convert.FromHexString(storedCode);

        var bytes = Encoding.ASCII.GetBytes(code);
        var hash = await SHA512.HashDataAsync(new MemoryStream(bytes));

        return CryptographicOperations.FixedTimeEquals(hash, storedHash);
    }
}

public class Rfc2898DeriveBytesHashingUtilities
{
    private const int KeySize = 32;
    private const int Iterations = 10_000;
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    public string ToHashedCode(string toHash, string userId)
    {
        var salt = Encoding.UTF8.GetBytes(userId);

        var hash = Rfc2898DeriveBytes.Pbkdf2(toHash, salt, Iterations, Algorithm, KeySize);

        return Convert.ToBase64String(hash);
    }

    public bool VerifyCode(string code, string userId, string storedCode)
    {
        var salt = Encoding.UTF8.GetBytes(userId);
        var storedHash = Convert.FromBase64String(storedCode);

        var hash = Rfc2898DeriveBytes.Pbkdf2(code, salt, Iterations, Algorithm, KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, storedHash);
    }
}