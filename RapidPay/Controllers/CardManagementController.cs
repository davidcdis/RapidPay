using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.API.Filters;
using RapidPay.Core;
using RapidPay.Core.Abstractions;
using RapidPay.Core.Domain.Services;
using RapidPay.Dtos.Requests;

namespace RapidPay.Controllers
{
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(RapidPayExceptionFilter))]
    public class CardManagementController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardManagementController(ICardService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        /// Creates a card.
        /// </summary>
        [HttpPost]
        [Route("/card-management/cards")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Post))]
        public IActionResult CreateCard(CreateCardRequest request)
        {
            Card newCard = _cardService.CreateCard(request.Number,request.CVV,request.Balance, request.ExpirationDate);
            return Ok(newCard);
        }

        /// <summary>
        /// Gets a card balance
        /// </summary>
        [HttpGet]
        [Route("/card-management/cards/{Number}/balance")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Get))]
        public IActionResult GetCardBalance([FromRoute] GetCardBalanceRequest request)
        {
            decimal balance = _cardService.GetCardBalance(request.Number);
            return Ok(balance);
        }
    }
}
