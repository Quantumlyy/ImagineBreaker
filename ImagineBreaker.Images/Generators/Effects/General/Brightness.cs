using System.Threading.Tasks;
using ImageMagick;
using static ImagineBreaker.Util.ImagineBreakerSingletons;

namespace ImagineBreaker.Images.Generators.Effects.General
{
    public static class Brightness
    {
        public static async Task<byte[]> GenerateAsync(string targetImage, int brightness)
        {
            using (var image = new MagickImage(await HttpClient.GetByteArrayAsync(targetImage)))
            {
                image.BrightnessContrast(new Percentage(brightness), new Percentage(100));
                return image.ToByteArray();
            }
        }
    }
}