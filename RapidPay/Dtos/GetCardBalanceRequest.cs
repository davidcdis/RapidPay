using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RapidPay.Dtos.Requests
{
    public record GetCardBalanceRequest(
       
        [Required(ErrorMessage = "Card number is required")]
        [StringLength(15,MinimumLength = 15)]
        string Number);
    
}
