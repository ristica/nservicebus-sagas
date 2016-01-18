
using System;

namespace Nsb.Dispatch
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            if (Environment.UserInteractive)
                Console.Title = "Dispatcher";

            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
