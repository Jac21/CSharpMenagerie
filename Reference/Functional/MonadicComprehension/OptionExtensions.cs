namespace MonadicComprehension
{
    internal static class OptionExtensions
    {
        /// <summary>
        ///  Resolves an environment variable, or returns 'none' if it's not set
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Option<string> GetEnvironmentVariable(string name)
        {
            var value = "64"; // Environment.GetEnvironmentVariable();

            if (value is null)
                return Option<string>.None();

            return Option<string>.Some(value);
        }

        /// <summary>
        /// Converts a string to integer, or returns 'none' in case of failure
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Option<int> ParseInt(string str) =>
            int.TryParse(str, out var result)
                ? Option<int>.Some(result)
                : Option<int>.None();
    }
}