using System.Net.Http;
using ImagineBreaker.Util;

namespace ImagineBreaker.Games.Fortnite
{
    public class FortniteClient
    {
        public static FortniteClient Client = new FortniteClient();
        
        private const string ApiUrl = "https://fortnite-api.theapinetwork.com/";
        private readonly HttpClient _httpClient = ImagineBreakerSingletons.HttpClient;
        private readonly string _token;

        public FortniteClient()
        {
            _token = "9c72c3fffe74a5e6c1a53d6f96d98352";
            _httpClient.DefaultRequestHeaders.Add("Authorization", _token);
        }
    }
}