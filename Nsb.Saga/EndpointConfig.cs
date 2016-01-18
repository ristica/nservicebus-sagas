
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

            configuration.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Nsb") && t.Name.EndsWith("Command"));
            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
