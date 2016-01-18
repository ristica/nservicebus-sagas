using System;
using Nsb.Shared;
using NServiceBus;

namespace Nsb.Messages
{
    public class OrderPlannedMessage: IMessage
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}