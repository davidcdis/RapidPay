namespace RapidPay.Core.Exceptions
{
    [Serializable]
    public class UniqueCardException : Exception
    {
        public UniqueCardException() { }

        public UniqueCardException(string number) 
            : base(String.Format("Card number {0} already exists", number)) { }

        protected UniqueCardException(
         System.Runtime.Serialization.SerializationInfo info,
         System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
