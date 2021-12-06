using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Order
    {
        [JsonPropertyName("orderId"), Key]
        public int OrderId { get; set; }
        
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
        
        [JsonPropertyName("address"), Required]
        public string Address { get; set; }
        
        [JsonPropertyName("totalPrice")]
        public double TotalPrice { get; set; }
        
        [JsonPropertyName("date")]
        public string Date { get; set; }
        
        
    }
}