using System;
using System.Net.Http;

namespace ImagineBreaker.Util
{
    public static class ImagineBreakerSingletons
    {
        private static readonly Lazy<HttpClient> LazyHttpClient = new Lazy<HttpClient>(() => 
            new HttpClient());
        
        public static HttpClient HttpClient
            => LazyHttpClient.Value;
    }
}