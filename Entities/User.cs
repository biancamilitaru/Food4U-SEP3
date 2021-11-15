using System.Text.Json.Serialization;

namespace Food4U_SEP3.Models
{
    public class User
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}