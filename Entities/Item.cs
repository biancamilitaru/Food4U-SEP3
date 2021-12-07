using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Item
    {
        [JsonPropertyName("itemID"), Key]
        public int ItemId { get; set; }
        
        [Required, JsonPropertyName("name")]
        public string Name { get; set; }
        
        [Required,JsonPropertyName("description"),MaxLength(500)]
        public string Description { get; set; }
        
        [Required, JsonPropertyName("price")]
        public string Price { get; set; }
        
        [Required, JsonPropertyName("categoryId")]
        public string CategoryId { get; set; } 
        
        [JsonPropertyName("discount")]
        public int Discount { get; set; }
    }
}