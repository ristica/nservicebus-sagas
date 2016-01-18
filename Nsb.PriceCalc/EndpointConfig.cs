
using System;

namespace Nsb.PriceCalc
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            if (Environment.UserInteractive)
                Console.Title = "Price Calculator";

            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
