using NServiceBus;

namespace Nsb.Messages
{
    public class PriceRequest : IMessage
    {
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
