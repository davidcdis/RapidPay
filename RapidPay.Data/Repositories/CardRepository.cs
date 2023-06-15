using RapidPay.Core;
using RapidPay.Core.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Data.Repositories
{
    // Card Repository
    // This is our in memory database, should be managed by Ioc Container as Singleton
    public class CardRepository : ICardRepository
    {
        private readonly List<Card> _cards;

        public CardRepository()
        {
            _cards = new List<Card>()
            {
                new Card(){ Number = "123456789123456", Balance = 1250, CVV = "123" },
                new Card(){ Number = "000000000000000", Balance = 0, CVV = "000" },
                new Card(){ Number = "111111111111111", Balance = 2500, CVV = "111" }
            };
        }
        public void InsertCard(Card card)
        {
            if(!_cards.Any(c=> c.Number == card.Number))
            {
                _cards.Add(card);
            }   
        }

        public void UpdateCardBalance(string cardNumber, decimal balance)
        {
            foreach (var card in _cards.Where(p => p.Number == cardNumber))
            {
                card.Balance = balance;
            }
        }

        public Card GetCardByNumber(string cardNumber)
        {
            Card card = _cards.FirstOrDefault(c => c.Number == cardNumber);
            return card;
        }
    }
}
