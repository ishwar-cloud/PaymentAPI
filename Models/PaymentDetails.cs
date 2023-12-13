using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentDetailsId { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(100)")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only alphabets are allowed for Card Owner Name")]
        public string? CardOwnerName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(16)")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers are allowed for Card Number")]
        public string? CardNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]

        public string? ExpirationDate { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(3)")]

        public string? SecurityCode { get; set; }
    }
}
