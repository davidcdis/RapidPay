using System.Timers;

namespace RapidPay.Core.Abstractions
{
    public interface IUniversalFeeExchangeService
    {
        decimal GetFee();
        void UpdateFee(object src, ElapsedEventArgs e);
    }
}