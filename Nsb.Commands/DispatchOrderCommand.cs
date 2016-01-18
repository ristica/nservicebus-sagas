using System;
using Nsb.Shared;
using NServiceBus;

namespace Nsb.Commands
{
    public class DispatchOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
    }
}
