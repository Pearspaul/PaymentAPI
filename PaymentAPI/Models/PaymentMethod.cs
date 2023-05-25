using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodCode { get; set; }
        public bool IsActive { get; set; }
        public string AdditionalDetails { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
