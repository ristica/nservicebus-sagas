using System;
using Nsb.Commands;
using Nsb.Messages;
using Nsb.Shared;
using NServiceBus;

namespace Nsb.Sales
{
    public class AcceptOrderHandler : IHandleMessages<AcceptOrderCommand>
    {
        private readonly IBus _bus;

        public AcceptOrderHandler(IBus bus)
        {
            this._bus = bus;
        }

        public void Handle(AcceptOrderCommand message)
        {
            // set status of the message
            Console.WriteLine();
            Console.WriteLine("2) Order {0} accepted!", message.OrderId);

            this._bus.Reply(
                new OrderPlannedMessage
                {
                    OrderId = message.OrderId,
                    Status = OrderStatus.Accepted
                });

            Console.WriteLine();
            Console.WriteLine("3) Sending order {0} back to saga", message.OrderId);
        }
    }
}
