using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace PaymentAPI.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public Guid TransactionID { get; set; }
        public string SenderEmail { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public decimal AmountFrom { get; set; }
        public decimal AmountTo { get; set; }
        public DateTime ConvertedDate { get; set; }
        public decimal ExchangeRate { get; set; }
        public int PaymentMethodID { get; set; }
        public string PaymentStatus { get; set; }
        public int CustomerID { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionType { get; set; }
        public string? PaymentReference { get; set; }
        public string? AdditionalNotes { get; set; }
        public string SenderAccountNumber { get; set; }
        public string ReceiverAccountNumber { get; set; }
    }
}
