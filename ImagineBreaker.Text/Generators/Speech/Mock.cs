using System;
using ImagineBreaker.Text.Interfaces;

namespace ImagineBreaker.Text.Generators.Speech
{
    public class MockString : ITextTransform
    {
        public static MockString Mock => LazyInstance.Value;
        private static Lazy<MockString> LazyInstance { get; }
            = new Lazy<MockString>(() => new MockString());
        
        public string Generate(string baseText)
        {
            var chars = baseText.ToUpper().Split("");
            for (int i = 0; i < chars.Length; i += 2)
                chars[i] = chars[i].ToLower();
            
            return String.Join("", chars);
        }
    }
}