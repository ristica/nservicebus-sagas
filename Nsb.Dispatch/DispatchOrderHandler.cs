using System;
using Nsb.Commands;
using Nsb.Messages;
using Nsb.Shared;
using NServiceBus;

namespace Nsb.Dispatch
{
    public class DispatchOrderHandler : IHandleMessages<DispatchOrderCommand>
    {
        private readonly IBus _bus;

        public DispatchOrderHandler(IBus bus)
        {
            this._bus = bus;
        }

        public void Handle(DispatchOrderCommand message)
        {
            Console.WriteLine();
            Console.WriteLine("6) Dispatching order {0} to address: {1}", message.OrderId, message.Address);

            // no need for configuration because of Reply!
            var response = new OrderDispatchedMessage 
            { 
                OrderId = message.OrderId, 
                Status = OrderStatus.Dispatched 
            };
            this._bus.Reply(response);

            Console.WriteLine();
            Console.WriteLine("7) Sending order {0} back to saga", message.OrderId);
        }
    }
}
