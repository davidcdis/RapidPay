using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Core.Repositories
{
    public interface ICardRepository
    {
        void InsertCard(Card card);

        Card GetCardByNumber(string cardNumber);

        void UpdateCardBalance(string cardNumber, decimal balance);

    }
}
