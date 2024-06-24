using System.ComponentModel.DataAnnotations;

namespace PaymentManagerService.Models
{
    public class Payment
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public long CardNumber { get; set; }
        [Required]
        public int CardCVV { get; set; }
        [Required]
        public string CardExpirationDate { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
