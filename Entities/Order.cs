using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Food4U_SEP3.Models;

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
        
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
        [JsonPropertyName("customerUsername"), ForeignKey("username")]
        public string CustomerUsername { get; set; }
        
        [JsonPropertyName("restaurantUsername"), ForeignKey("username")]
        public string RestaurantUsername { get; set; }
        
        [JsonPropertyName("deliveryID"), ForeignKey("delivery_id")]
        public int DeliveryId { get; set; }
        
    }
}