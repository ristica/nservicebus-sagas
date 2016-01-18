using System;
using NServiceBus.Saga;

namespace Nsb.Saga
{
    public class ProcessOrderSagaData : ContainSagaData
    {
        [Unique]
        public Guid OrderId { get; set; }
        public string Article { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }
    }
}
