using RapidPay.Core.Abstractions;
using RapidPay.Core.Domain.Entities;
using RapidPay.Core.Exceptions;
using RapidPay.Core.Repositories;

namespace RapidPay.Core.Domain.Services
{
    public class CardPaymentService: ICardPaymentService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUniversalFeeExchangeService _universalFeeExchangeService;

        public CardPaymentService(
            ICardRepository cardRepository, 
            IUniversalFeeExchangeService universalFeeExchangeService)
        {
            _cardRepository = cardRepository;
            _universalFeeExchangeService = universalFeeExchangeService;
        }

        public PaymentReceipt PayCard(string number, decimal amount)
        {
            // Validate that the card exists in the database 
            Card card = _cardRepository.GetCardByNumber(number);
            
            if(card == null)
            {
                throw new CardNotFoundException(number);
            }

            try
            {
                // Get the current fee from UFE Service and calculate the fee for this payment
                decimal fee = _universalFeeExchangeService.GetFee() * amount;

                // Save Current Balance for receipt, and calculate the new balance
                decimal cardBalanceBefore = card.Balance;
                decimal newBalance = card.Balance - amount + fee;

                // Update card balance 
                _cardRepository.UpdateCardBalance(number, newBalance);

                // Return a receipt
                PaymentReceipt receipt = new(
                    number,
                    amount, 
                    fee,
                    cardBalanceBefore,
                    newBalance);
                return receipt;
            }
            // If something unexpected happens, just log the exception, re throw and let the consumer deal with it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            } 
        }
    } 
}
