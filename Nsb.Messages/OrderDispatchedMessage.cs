using System;
using Nsb.Shared;

namespace Nsb.Messages
{
    public class OrderDispatchedMessage
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
