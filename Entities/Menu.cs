using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Menu
    {
        [JsonPropertyName("menuID"), Key]
        public int MenuId { get; set; }
        
        
        [Required, JsonPropertyName("description")]
        public string Description { get; set; }
        
        
        [Required, JsonPropertyName("username")]
        public string UserName { get; set; }
        
        
        [JsonPropertyName("categories")]
        public IList<Category> Categories { get; set; }
    }
}