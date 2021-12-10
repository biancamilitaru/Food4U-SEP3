using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Food4U_SEP3.Models;

namespace Entities
{
    public class Driver : User
    {
        [Required,JsonPropertyName("firstName"),MaxLength(50)]
        public string FirstName;
        [Required,JsonPropertyName("lastName"),MaxLength(50)]
        public string LastName;
        [Required,JsonPropertyName("address"), MaxLength(100)]
        public string Address;
        [Required,JsonPropertyName("phoneNumber"),MaxLength(12)]
        public string PhoneNumber;
        [Required,JsonPropertyName("email"),MaxLength(100)]
        public string Email;
        [Required,JsonPropertyName("licenseNumber"),MaxLength(50)]
        public string LicenseNumber;
    }
}