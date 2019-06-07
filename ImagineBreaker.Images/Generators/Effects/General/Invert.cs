using System.Threading.Tasks;
using ImageMagick;
using static ImagineBreaker.Util.ImagineBreakerSingletons;

namespace ImagineBreaker.Images.Generators.Effects.General
{
    public static class Invert
    {
        public static async Task<byte[]> GenerateAsync(string targetImage)
        {
            using (var image = new MagickImage(await HttpClient.GetByteArrayAsync(targetImage)))
            {
                image.Negate();
                return image.ToByteArray();
            }
        }
    }
}