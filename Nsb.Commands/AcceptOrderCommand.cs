using System;
using Nsb.Shared;

namespace Nsb.Commands
{
    /// <summary>
    /// NOTE: no need for ICommand implementation
    /// </summary>
    public class AcceptOrderCommand
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
