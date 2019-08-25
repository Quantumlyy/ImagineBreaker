using System;
using System.Threading.Tasks;
using ImageMagick;
using ImagineBreaker.Images.Interfaces;
using static ImagineBreaker.Util.ImagineBreakerSingletons;

namespace ImagineBreaker.Images.Generators.Effects.General
{
    public class GrayscaleEffect : IImageEffect
    {
        public static GrayscaleEffect Grayscale => LazyInstance.Value;
        private static Lazy<GrayscaleEffect> LazyInstance { get; }
            = new Lazy<GrayscaleEffect>(() => new GrayscaleEffect());
        
        public async Task<byte[]> ModifyAsync(string targetImage)
        {
            using var image = new MagickImage(await HttpClient.GetByteArrayAsync(targetImage));
            image.Grayscale();
            return image.ToByteArray();
        }
    }
}