using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Restaurant
    {
        [JsonPropertyName("name"), MaxLength(50)]
        public string Name { get; set; }
        
        [JsonPropertyName("address"), MaxLength(100)]
        public string Address { get; set; }
        
        [JsonPropertyName("phone_number"),MaxLength(12)]
        public string PhoneNumber { get; set; }
        
        [JsonPropertyName("opening_hours_monday"), MaxLength(100)]
        public string OpeningHoursMonday { get; set; }
        
        [JsonPropertyName("opening_hours_tuesday"), MaxLength(100)]
        public string OpeningHoursTuesday { get; set; }
        
        [JsonPropertyName("opening_hours_wednesday"), MaxLength(100)]
        public string OpeningHoursWednesday { get; set; }
        
        [JsonPropertyName("opening_hours_thursday"), MaxLength(100)]
        public string OpeningHoursThursday { get; set; }
        
        [JsonPropertyName("opening_hours_friday"), MaxLength(100)]
        public string OpeningHoursFriday { get; set; }
        
        [JsonPropertyName("opening_hours_saturday"), MaxLength(100)]
        public string OpeningHoursSaturday { get; set; }
        
        [JsonPropertyName("opening_hours_sunday"), MaxLength(100)]
        public string OpeningHoursSunday { get; set; }
        
        [JsonPropertyName("description"),MaxLength(500)]
        public string Description { get; set; }
        
        [JsonPropertyName("restaurantID"), Key]
        public int RestaurantId { get; set; }
        
        [JsonPropertyName("delivery_option_1")]
        public Delivery DeliveryOption1 { get; set; }
        
        [JsonPropertyName("delivery_option_2")]
        public Delivery DeliveryOption2 { get; set; }

    }
}