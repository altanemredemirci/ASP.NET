namespace _06_CustomHelpers.Helpers
{
    public static class StringHelper //içineki her tanım static olmak zorunda
    {
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static string CapitalizeWords(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = CapitalizeFirstLetter(words[i]);
            }

            return string.Join(' ', words);
        }
    }
}
