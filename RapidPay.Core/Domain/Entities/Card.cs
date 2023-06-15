namespace RapidPay.Core
{
    public class Card
    {
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; }
        public decimal Balance { get; set; }
    }
}