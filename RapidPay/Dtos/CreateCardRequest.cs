using System.ComponentModel.DataAnnotations;

namespace RapidPay.Dtos.Requests
{
    public record CreateCardRequest(
        [Required(ErrorMessage = "Card number is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Card number must be valid Number")]
        [StringLength(15,MinimumLength = 15)]
        string Number, 

        [Required(ErrorMessage = "CVV is required")]
        [RegularExpression("([0-9]+)", ErrorMessage = "CVV must be valid Number")]
        [StringLength(3,MinimumLength = 3)]
        string CVV,

        [Required(ErrorMessage = "Balance is required")]
        decimal Balance,

        [Required(ErrorMessage = "Expiration Date is required")] 
        DateTime ExpirationDate);
    
}
