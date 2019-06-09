using System;
using System.Threading.Tasks;
using ImageMagick;
using ImagineBreaker.Images.Interfaces;
using static ImagineBreaker.Util.ImagineBreakerSingletons;

namespace ImagineBreaker.Images.Generators.Effects.General
{
    public class BrightnessEffect: IImageEffect
    {
        public int BrightnessValue { get; set; }
        
        public static BrightnessEffect Brightness => LazyInstance.Value;
        private static Lazy<BrightnessEffect> LazyInstance { get; }
            = new Lazy<BrightnessEffect>(() => new BrightnessEffect());
        
        public async Task<byte[]> ModifyAsync(string targetImage)
        {
            using (var image = new MagickImage(await HttpClient.GetByteArrayAsync(targetImage)))
            {
                image.BrightnessContrast(new Percentage(BrightnessValue), new Percentage(100));
                return image.ToByteArray();
            }
        }
    }
}