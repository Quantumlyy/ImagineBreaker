using System.Threading.Tasks;

namespace ImagineBreaker.Images.Interfaces
{
    public interface IImageAction
    { 
        Task<byte[]> GenerateAsync(string target);
    } 
}