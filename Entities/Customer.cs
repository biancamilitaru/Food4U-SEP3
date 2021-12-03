using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Food4U_SEP3.Models;

namespace Entities
{
    public class Customer :User
    {

        [Required,JsonPropertyName("firstName"),MaxLength(50)]
        
        public string FirstName { get; set; }

        [Required,JsonPropertyName("lastName"),MaxLength(50)]
        public string LastName { get; set; }

        [Required,JsonPropertyName("phoneNumber"),MaxLength(12)]
        public string PhoneNumber { get; set; }

        [Required,JsonPropertyName("email"),MaxLength(100)]
        public string Email { get; set; }

        [Required,JsonPropertyName("address"), MaxLength(100)]
        public string Address { get; set; }
        
    }
}