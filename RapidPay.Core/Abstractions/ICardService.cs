using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Core.Abstractions
{
    public interface ICardService
    {
        Card CreateCard(string number, string cvv, decimal balance, DateTime expirationDate);
        decimal GetCardBalance(string number);
    }
}
