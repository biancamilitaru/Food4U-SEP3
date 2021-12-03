using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Food4U_SEP3.Models;

namespace Entities
{
    public class Restaurant : User
    {
        [Required,JsonPropertyName("name"), MaxLength(50)]
        public string Name { get; set; }
        
        [Required,JsonPropertyName("address"), MaxLength(100)]
        public string Address { get; set; }
        
        [Required,JsonPropertyName("phoneNumber"),MaxLength(12)]
        public string PhoneNumber { get; set; }
        
        [Required,JsonPropertyName("openingHoursMonday"), MaxLength(100)]
        public string OpeningHoursMonday { get; set; }
        
        [Required,JsonPropertyName("openingHoursTuesday"), MaxLength(100)]
        public string OpeningHoursTuesday { get; set; }
        
        [Required,JsonPropertyName("openingHoursWednesday"), MaxLength(100)]
        public string OpeningHoursWednesday { get; set; }
        
        [Required,JsonPropertyName("openingHoursThursday"), MaxLength(100)]
        public string OpeningHoursThursday { get; set; }
        
        [Required,JsonPropertyName("openingHoursFriday"), MaxLength(100)]
        public string OpeningHoursFriday { get; set; }
        
        [Required,JsonPropertyName("openingHoursSaturday"), MaxLength(100)]
        public string OpeningHoursSaturday { get; set; }
        
        [Required,JsonPropertyName("openingHoursSunday"), MaxLength(100)]
        public string OpeningHoursSunday { get; set; }
        
        [Required,JsonPropertyName("description"),MaxLength(500)]
        public string Description { get; set; }

        [JsonPropertyName("deliveryOption1")]
        public Delivery DeliveryOption1 { get; set; }
        
        [JsonPropertyName("deliveryOption2")]
        public Delivery DeliveryOption2 { get; set; }
        
        [JsonPropertyName("menu")]
        public Menu Menu { get; set; }
        
        [JsonPropertyName("visibility")]
        public bool Visibility { get; set; }

    }
}