using System;
using System.Threading.Tasks;
using ImageMagick;
using ImagineBreaker.Images.Interfaces;
using static ImagineBreaker.Util.ImagineBreakerSingletons;

namespace ImagineBreaker.Images.Generators.Images.Fun
{
    public class SlapImage : IImageInteraction
    {
        public static SlapImage Slap => LazyInstance.Value;
        private static Lazy<SlapImage> LazyInstance { get; }
            = new Lazy<SlapImage>(() => new SlapImage());
        
        public async Task<byte[]> GenerateAsync(string target, string invoker)
        {
            using (var mask = new MagickImage(@"./Assets/Images/Slap/slap_mask.png"))
            using (var image = new MagickImage(@"./Assets/Images/Slap/slap.png"))
            using (var invokerImage = new MagickImage(await HttpClient.GetByteArrayAsync(invoker)))
            using (var targetImage = new MagickImage(await HttpClient.GetByteArrayAsync(target)))
            {
                targetImage.BackgroundColor = MagickColors.Transparent;
                image.BackgroundColor = MagickColors.Transparent;

				
                targetImage.Resize(169, 169);
                invokerImage.Resize(131, 131);

                image.SetWriteMask(mask);
                image.Composite(targetImage, 159, 180, CompositeOperator.Over);
                image.Composite(invokerImage, 410, 107, CompositeOperator.Over);

                return image.ToByteArray();
            }
        }
    }
}