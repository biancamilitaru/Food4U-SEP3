using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Food4U_SEP3.Models
{
    public class User
    {
        [JsonPropertyName("username"), Key]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}