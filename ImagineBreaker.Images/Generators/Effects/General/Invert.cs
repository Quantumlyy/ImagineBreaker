using System;
using System.Threading.Tasks;
using ImageMagick;
using ImagineBreaker.Images.Interfaces;
using static ImagineBreaker.Util.ImagineBreakerSingletons;

namespace ImagineBreaker.Images.Generators.Effects.General
{
    public class InvertEffect : IImageEffect
    {
        public static InvertEffect Invert => LazyInstance.Value;
        private static Lazy<InvertEffect> LazyInstance { get; }
            = new Lazy<InvertEffect>(() => new InvertEffect());
        
        public async Task<byte[]> ModifyAsync(string targetImage)
        {
            using (var image = new MagickImage(await HttpClient.GetByteArrayAsync(targetImage)))
            {
                image.Negate();
                return image.ToByteArray();
            }
        }
    }
}