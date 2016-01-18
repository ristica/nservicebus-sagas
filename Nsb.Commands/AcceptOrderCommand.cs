using System;
using Nsb.Shared;

namespace Nsb.Commands
{
    public class AcceptOrderCommand
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
