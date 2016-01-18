
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

            configuration.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Nsb") && t.Name.EndsWith("Command"));
            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
