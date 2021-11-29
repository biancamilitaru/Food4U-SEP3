using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Menu
    {
        [Required, JsonPropertyName("description")]
        public string Description { get; set; }
    }
}