using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Category
    {
        [Key, Required, JsonPropertyName("categoryId")]
        public int CategoryId;
        
        [Required, JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("menuID")]
        public int MenuId { get; set; }
    }
}