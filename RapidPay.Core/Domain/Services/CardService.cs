using RapidPay.Core.Abstractions;
using RapidPay.Core.Exceptions;
using RapidPay.Core.Repositories;

namespace RapidPay.Core.Domain.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        // Creates a card in the database 
        public Card CreateCard(string number, string cvv, decimal balance, DateTime expirationDate)
        {
            // Validate that the card is not already in the database 
            Card card = _cardRepository.GetCardByNumber(number);
            if(card != null)
            {
                throw new UniqueCardException(number);
            }

            try
            {
                // Create a new card object and store in database 
                Card newCard = new()
                {
                    Number = number,
                    CVV = cvv,
                    ExpirationDate = expirationDate,
                    Balance = balance
                };

                _cardRepository.InsertCard(newCard);
                return newCard;
            }
            // If something unexpected happens, just log the exception, re throw and let the consumer deal with it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public decimal GetCardBalance(string number)
        {
            // Validate that the card number exists
            Card card = _cardRepository.GetCardByNumber(number);
            if (card == null)
            {
                throw new CardNotFoundException(number);
            }
            return card.Balance;
        }
    }
}
