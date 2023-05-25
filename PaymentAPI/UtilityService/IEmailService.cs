using PaymentAPI.Models;

namespace PaymentAPI.UtilityService
{
    public interface IEmailService
    {
        void SendEmail(EmailModel emailModel);
    }
}
