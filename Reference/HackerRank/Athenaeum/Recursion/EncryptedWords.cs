namespace Athenaeum.Recursion
{
    public static class EncryptedWords
    {
        public static string FindEncryptedWord(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            
            var result = string.Empty;

            var middle = s.Length / 2;

            if (s.Length % 2 == 0)
            {
                middle -= 1;
            }

            result += s[middle];

            if (middle > 0)
            {
                var ls = s[..middle];

                result += FindEncryptedWord(ls);
            }

            if (middle < s.Length - 1)
            {
                var rs = s[(middle + 1)..];

                result += FindEncryptedWord(rs);
            }

            return result;
        }
    }
}