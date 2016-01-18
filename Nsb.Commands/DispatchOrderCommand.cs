using System;
using Nsb.Shared;

namespace Nsb.Commands
{
    public class DispatchOrderCommand
    {
        public Guid OrderId { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
    }
}
