using System.Threading.Tasks;
using ImageMagick;
using static ImagineBreaker.Util.ImagineBreakerSingletons;

namespace ImagineBreaker.Images.Generators.Effects.General
{
    public static class Grayscale
    {
        public static async Task<byte[]> GenerateAsync(string targetImage)
        {
            using (var image = new MagickImage(await HttpClient.GetByteArrayAsync(targetImage)))
            {
                image.Grayscale();
                return image.ToByteArray();
            }
        }
    }
}