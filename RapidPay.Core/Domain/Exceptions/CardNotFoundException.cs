namespace RapidPay.Core.Exceptions
{
    [Serializable]
    public class CardNotFoundException : Exception
    {
        public CardNotFoundException() { }

        public CardNotFoundException(string number)
            : base(String.Format("Card number {0} is not found", number)) { }

        protected CardNotFoundException(
         System.Runtime.Serialization.SerializationInfo info,
         System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
