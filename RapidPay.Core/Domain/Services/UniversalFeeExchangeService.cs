using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using RapidPay.Core.Abstractions;

namespace RapidPay.Core.Domain.Services
{
    // Universal Fee Exchange Service
    // Starts with a random decimal from 0 to 2
    // updateInterval is in minutes, default value is 60 minutes
    public class UniversalFeeExchangeService : IUniversalFeeExchangeService
    {
        private decimal _currentFee;
        private readonly int _updateInterval = 60;

        public UniversalFeeExchangeService()
        {
            // Randomly initialize Fee 
            _currentFee = GetRandomDecimal(0, 2);
            Console.WriteLine($"Current Fee exchange: {_currentFee}");

            // Initialize Timmer
            System.Timers.Timer _timer = new System.Timers.Timer(60 * _updateInterval * 1000);
            _timer.Elapsed += new ElapsedEventHandler(UpdateFee!);
            _timer.Start();
        }

        public decimal GetFee()
        {
            return _currentFee;
        }

        public void UpdateFee(object src, ElapsedEventArgs e)
        {
            _currentFee *= GetRandomDecimal(0, 2);
            Console.WriteLine($"Fee exchange has been updated to {_currentFee}");
        }

        private decimal GetRandomDecimal(double min, double max)
        {
            Random random = new();
            double randomnumber = random.NextDouble() * (max - min) + min;
            return (decimal)randomnumber;
        }
    }
}
