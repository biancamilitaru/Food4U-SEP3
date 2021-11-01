using System.Text.Json.Serialization;

namespace Client.Models
{
    public class User
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}