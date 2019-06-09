using System;
using System.Threading.Tasks;

namespace ImagineBreaker.Images.Interfaces
{
    public interface IImageInteraction
    {
        Task<byte[]> GenerateAsync(string target, string invoker);
    } 
}