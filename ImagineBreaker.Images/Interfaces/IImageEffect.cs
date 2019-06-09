using System.Threading.Tasks;

namespace ImagineBreaker.Images.Interfaces
{
    public interface IImageEffect
    {
        
        Task<byte[]> ModifyAsync(string targetImage);
    }
}