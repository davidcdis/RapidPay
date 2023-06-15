using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidPay.API.Filters;
using RapidPay.Core.Abstractions;
using RapidPay.Core.Domain.Entities;
using RapidPay.Core.Domain.Services;
using RapidPay.Dtos.Requests;

namespace RapidPay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(RapidPayExceptionFilter))]
    [Authorize]
    public class PaymentFeesController : ControllerBase
    {
        private readonly ICardPaymentService _paymentService;
        public PaymentFeesController(ICardPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Processes a card payment
        /// </summary>
        [HttpPost]
        [Route("/payment-fees/card/pay")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Post))]
        public IActionResult Pay([FromBody] PayCardRequest request)
        {
            PaymentReceipt receipt =  _paymentService.PayCard(request.Number, request.Amount);
            return Ok(receipt);     
        }
    }
}
