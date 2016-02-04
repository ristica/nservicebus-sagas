using System;
using Nsb.Messages;
using NServiceBus;

namespace Nsb.PriceCalc
{
    public class PriceCalcHandler : IHandleMessages<PriceRequestMessage>
    {
        private readonly IBus _bus;

        public PriceCalcHandler(IBus bus)
        {
            this._bus = bus;
        }

        public void Handle(PriceRequestMessage message)
        {
            var total = Service.PriceCalculator.GetPrice(message);

            Console.WriteLine();
            Console.WriteLine("Calculating total price: EUR {0}", total);

            this._bus.Reply(
                new PriceResponseMessage
                {
                    Total = total
                });
        }
    }
}
