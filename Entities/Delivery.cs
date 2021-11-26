using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Delivery
    {
        [Key, JsonPropertyName("deliveryID")]
        public string DeliveryId { get; set; }
        [Required,MaxLength(50), JsonPropertyName("deliveryName")]
        public string DeliveryName { get; set; }
        [Required, JsonPropertyName("price")]
        public int Price { get; set; }

    }
}