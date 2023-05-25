namespace PaymentAPI.Models.Dto
{
    public class PaymentDto
    {
        public string? SenderEmail { get; set; }
        public string? CurrencyFrom { get; set; }
        public string? CurrencyTo { get; set; }
        public decimal AmountFrom { get; set; }
        public decimal AmountTo { get; set; }
        public decimal ExchangeRate { get; set; }
        public int CustomerID { get; set; }
        public string? AdditionalNotes { get; set; }
        public string? SenderAccountNumber { get; set; }
        public string? ReceiverAccountNumber { get; set; }
        public string? AdminEmail { get; set; }
    }
}
