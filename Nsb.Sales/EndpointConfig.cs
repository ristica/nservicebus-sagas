
using System;

namespace Nsb.Sales
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            if (Environment.UserInteractive)
                Console.Title = "Sales";

            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
