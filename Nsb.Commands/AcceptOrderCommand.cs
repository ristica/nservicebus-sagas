using System;
using Nsb.Shared;
using NServiceBus;

namespace Nsb.Commands
{
    public class AcceptOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
