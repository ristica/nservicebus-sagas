using System;
using Nsb.Shared;

namespace Nsb.Messages
{
    public class OrderProcessedMessage
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
