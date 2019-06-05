using System.Net.Http;
using System.Threading.Tasks;
using ImagineBreaker.Games.Fortnite.Responses;
using ImagineBreaker.Util;
using Newtonsoft.Json;

namespace ImagineBreaker.Games.Fortnite
{
    public class FortniteClient
    {
        public static FortniteClient Client = new FortniteClient();
        
        private const string ApiUrl = "https://fortnite-api.theapinetwork.com";
        private readonly HttpClient _httpClient = ImagineBreakerSingletons.HttpClient;
        private readonly string _token;

        public FortniteClient()
        {
            _token = "9c72c3fffe74a5e6c1a53d6f96d98352";
            _httpClient.DefaultRequestHeaders.Add("Authorization", _token);
        }

        public async Task<Users> GetUserAsync(string user)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}/users/id?username={user.ToLower()}");
            return JsonConvert.DeserializeObject<Users>(response.ToString());
        }
    }
}