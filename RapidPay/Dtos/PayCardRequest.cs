using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RapidPay.Dtos.Requests
{
    public record PayCardRequest(

        [Required(ErrorMessage = "Card number is required")]
        [StringLength(15,MinimumLength = 15)]
        string Number,

        [Required(ErrorMessage = "Amount is required")]
        decimal Amount);
    
}
