using System;
using Nsb.Shared;
using NServiceBus;

namespace Nsb.Messages
{
    public class OrderProcessedMessage : IMessage
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
