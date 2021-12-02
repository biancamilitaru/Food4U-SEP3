using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Delivery
    {
        [Key, JsonPropertyName("deliveryID")]
        public int DeliveryId { get; set; }
        [Required,MaxLength(50), JsonPropertyName("deliveryName")]
        public string DeliveryName { get; set; }
        
        [Required, JsonPropertyName("price")]
        public double Price { get; set; }
        
        [Required, JsonPropertyName("username")]
        public string UserName { get; set; }

    }
}