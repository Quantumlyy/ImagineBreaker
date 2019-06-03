using System.Threading.Tasks;
using ImageMagick;
using static ImagineBreaker.Util.ImagineBreakerSingletons;

namespace ImagineBreaker.Images.Generators.Images.Fun
{
    public static class Slap
    {
        public static async Task<MagickImage> GenerateAsync(string target, string invoker)
        {
            using (var mask = new MagickImage("D:\\Development\\WEBDEV\\Personal\\ImagineBreaker\\ImagineBreaker.Images\\Assets\\Images\\Slap\\slap_mask.png"))
            using (var image = new MagickImage("D:\\Development\\WEBDEV\\Personal\\ImagineBreaker\\ImagineBreaker.Images\\Assets\\Images\\Slap\\slap.png"))
            using (var invokerImage = new MagickImage(await HttpClient.GetByteArrayAsync(invoker)))
            using (var targetImage = new MagickImage(await HttpClient.GetByteArrayAsync(target)))
            {
                targetImage.BackgroundColor = MagickColors.Transparent;
                image.BackgroundColor = MagickColors.Transparent;

				
                targetImage.Resize(169, 169);
                targetImage.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 1.2f);
				
                invokerImage.Resize(131, 131);
                invokerImage.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 1.2f);

                image.SetWriteMask(mask);
                image.Composite(targetImage, 159, 180, CompositeOperator.Over);
                image.Composite(invokerImage, 410, 107, CompositeOperator.Over);
                
                return image;
            }
        }
    }
}