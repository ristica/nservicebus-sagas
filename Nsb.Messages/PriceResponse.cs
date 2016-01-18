using NServiceBus;

namespace Nsb.Messages
{
    public class PriceResponse : IMessage
    {
        public int Total { get; set; }
    }
}
