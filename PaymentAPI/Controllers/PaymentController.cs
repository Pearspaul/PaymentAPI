using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Context;
using PaymentAPI.Helpers;
using PaymentAPI.Models;
using PaymentAPI.Models.Dto;
using PaymentAPI.UtilityService;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController: ControllerBase
    {
        private readonly PaymentDbContext _paymentContext;
        private readonly IEmailService _emailService;

        public PaymentController(PaymentDbContext paymentDbContext, IEmailService emailService)
        {
            _paymentContext = paymentDbContext;
            _emailService = emailService;
        }

        /// <summary>
        /// create payment submit record in DB
        /// </summary>
        [Authorize]
        [HttpPost("submitPayment")]
        public async Task<IActionResult> SubmitPaymentDetails(PaymentDto paymentModel)
        {
            Payment paymentObj = new Payment();
            if (paymentModel is null)
                return BadRequest(Constants.InvalidRequest);
            paymentObj = PaymentDtoMapper.PaymentDtoMap(paymentModel);
            await _paymentContext.Payments.AddAsync(paymentObj);
            await _paymentContext.SaveChangesAsync();
            SendEmail(paymentModel.AdminEmail);

            return Ok(new
            {
                Message = Constants.TransactionTriggered
            });
        }

        /// <summary>
        /// Get all inprogress transactions
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("getTransactions")]
        public async Task<ActionResult<Payment>> GetAllTransaction()
        {
            return Ok(await _paymentContext.Payments.Where(x=>x.TransactionStatus==Constants.InProgress).ToListAsync());
        }

        /// <summary>
        /// update status of payment after approvel 
        /// </summary>
        /// <param name="paymentStatusDto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("updatePayment")]
        public async Task<IActionResult> updatePaymentStatus(PaymentStatusDto paymentStatusDto)
        {
            Payment transactionObj = new Payment();
            if (paymentStatusDto is null)
                return BadRequest(Constants.InvalidRequest);
            transactionObj = await _paymentContext.Payments.Where(x => x.Id == paymentStatusDto.PaymentId).FirstOrDefaultAsync();
            if (transactionObj is null)
                return BadRequest(Constants.InvalidRequest);
            transactionObj.TransactionStatus = paymentStatusDto.NewStatus;
            await _paymentContext.SaveChangesAsync();
            return Ok(new
            {
                Message = Constants.TransactionUpdated
            });
        }

        /// <summary>
        /// send email
        /// </summary>
        private void SendEmail(string email)
        {
            var emailModel = new EmailModel(email, Constants.TransactionDone, EmailBody.EmailStringBody());
            _emailService.SendEmail(emailModel);
        }
    }
}
