using System;
using NServiceBus;

namespace Nsb.Commands
{
    public class ProcessOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
        public string Article { get; set; } 
        public string Description { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}
