using Newtonsoft.Json;

namespace ImagineBreaker.Games.Fortnite.Responses
{
    public class Users
    {
        [JsonProperty("success")]
        public bool? Success { get; set; }
        
        [JsonProperty("error")]
        public string? Error { get; set; }
        
        [JsonProperty("eCode")]
        public string? ECode { get; set; }
        
        [JsonProperty("errorMessage")]
        public string? ErrorMessage { get; set; }
        
        [JsonProperty("data")]
        public UsersData? Data { get; set; }
    }

    public class UsersData
    {
        [JsonProperty("internalId")]
        public int InternalID { get; set; }
        
        [JsonProperty("uid")]
        public string UID { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("entries")]
        public UsersDataEntries[] Entries { get; set; }
    }

    public class UsersDataEntries
    {
        [JsonProperty("platform")]
        public string Platform { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("externalUid")]
        public string? ExternalUID { get; set; }
    }
}