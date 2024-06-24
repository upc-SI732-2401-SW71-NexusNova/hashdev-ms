namespace PaymentManagerService.Dtos
{
    public class PaymentCreateDto
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
        public long CardNumber { get; set; }
        public int CardCVV { get; set; }
        public string CardExpirationDate { get; set; }
        public int UserId { get; set; }
    }
}
