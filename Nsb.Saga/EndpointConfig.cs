
using System;

namespace Nsb.Saga
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration config)
        {
            if (Environment.UserInteractive)
                Console.Title = "Saga";

            // herewith we can avoid implementation of the ICommand interface in the Nsb.Commands assembly
            config.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Nsb") && t.Name.EndsWith("Command"));

            // herewith we can avoid implementation of the IMessage interface in the Nsb.Messages assembly
            config.Conventions().DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("Nsb") && t.Name.EndsWith("Message"));

            config.UsePersistence<InMemoryPersistence>();
        }
    }
}
