using System;

namespace Athenaeum.Cryptography
{
    public static class RotationalCipher
    {
        public static string RotateCipher(string input, int rotationFactor)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var result = string.Empty;

            foreach (var character in input)
            {
                if (char.IsLetter(character))
                {
                    var i = (char.ToLower(character) - 97 + rotationFactor) % 26;
                    var characterToAppend = char.IsUpper(character) ? i + 65 : i + 97;

                    result += (char) characterToAppend;
                }
                else if (char.IsDigit(character))
                {
                    var i = (character - 48 + rotationFactor) % 10;
                    var characterToAppend = i + 48;
                    
                    result += (char) characterToAppend;
                }
                else
                {
                    result += character;
                }
            }

            return result;
        }
    }
}