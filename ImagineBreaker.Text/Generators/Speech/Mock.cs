using System;

namespace ImagineBreaker.Text.Generators.Speech
{
    public static class Mock
    {
        public static string Generate(string baseText)
        {
            var chars = baseText.ToUpper().Split("");
            for (int i = 0; i < chars.Length; i += 2)
            {
                chars[i] = chars[i].ToLower();
            }

            return String.Join("", chars);
        }
    }
}