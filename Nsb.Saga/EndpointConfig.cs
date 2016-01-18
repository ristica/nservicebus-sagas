
using System;

namespace Nsb.Saga
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            if (Environment.UserInteractive)
                Console.Title = "Saga";

            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
