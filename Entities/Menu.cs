﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Menu
    {
        [JsonPropertyName("menuID"), Key]
        public int MenuId { get; set; }
        
        [Required, JsonPropertyName("description")]
        public string Description { get; set; }
        [Required, JsonPropertyName("userName")]
        public string UserName { get; set; }
    }
}