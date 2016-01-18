using System;
using Nsb.Shared;
using NServiceBus;

namespace Nsb.Messages
{
    public class OrderDispatchedMessage : IMessage
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
