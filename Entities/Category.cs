using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Category
    {
        [Key, Required, JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }
        
        [Required, JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("menuId")]
        public int MenuId { get; set; }
        [JsonPropertyName("items")]

        public IList<Item> Items { get; set; }
    }
}