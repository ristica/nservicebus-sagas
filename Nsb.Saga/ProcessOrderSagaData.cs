using System;
using NServiceBus.Saga;

namespace Nsb.Saga
{
    public class ProcessOrderSagaData : IContainSagaData
    {
        [Unique]
        public virtual Guid OrderId { get; set; }
        public virtual string Article { get; set; }
        public virtual string Description { get; set; }
        public virtual int Count { get; set; }
        public virtual int Price { get; set; }
        public virtual string Address { get; set; }

        public virtual Guid Id { get; set; }
        public virtual string Originator { get; set; }
        public virtual string OriginalMessageId { get; set; }
    }
}
