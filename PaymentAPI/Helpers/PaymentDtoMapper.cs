using Microsoft.VisualBasic;
using PaymentAPI.Models;
using PaymentAPI.Models.Dto;

namespace PaymentAPI.Helpers
{
    public class PaymentDtoMapper
    {
        /// <summary>
        /// Mapping UI model to db model
        /// </summary>
        public static Payment PaymentDtoMap(PaymentDto paymentDto)
        {
            Payment paymentObj = new Payment();
            paymentObj.SenderEmail = paymentDto.SenderEmail;
            paymentObj.CurrencyFrom = paymentDto.CurrencyFrom;
            paymentObj.CurrencyTo = paymentDto.CurrencyTo;
            paymentObj.AmountFrom = paymentDto.AmountFrom;
            paymentObj.AmountTo = paymentDto.AmountTo;
            paymentObj.ExchangeRate = paymentDto.ExchangeRate;
            paymentObj.CustomerID = paymentDto.CustomerID;
            paymentObj.AdditionalNotes = paymentDto.AdditionalNotes;
            paymentObj.SenderAccountNumber = paymentDto.SenderAccountNumber;
            paymentObj.ReceiverAccountNumber = paymentDto.ReceiverAccountNumber;
            paymentObj.TransactionID = Guid.NewGuid();
            paymentObj.ConvertedDate = DateTime.Now;
            paymentObj.PaymentStatus = Constants.Done;
            paymentObj.TransactionStatus = Constants.InProgress;
            paymentObj.TransactionType = Constants.Exchange;
            paymentObj.PaymentReference = Guid.NewGuid().ToString();

            return paymentObj;
        }
    }
}
