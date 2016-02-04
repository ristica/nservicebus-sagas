using NServiceBus;

namespace Nsb.Infrastructure
{
    public class ServiceBus
    {
        public static IBus Bus { get; private set; }
        private static readonly object Lock = new object();

        public static void Initialize(string endpointName)
        {
            if (Bus != null) return;
            lock (Lock)
            {
                if (Bus != null) return;
                var config = new BusConfiguration();
                config.UsePersistence<InMemoryPersistence>();
                config.UseTransport<MsmqTransport>();
                config.EndpointName(endpointName);

                // herewith we can avoid implementation of the ICommand interface in the Nsb.Commands assembly
                config.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Nsb") && t.Name.EndsWith("Command"));

                // herewith we can avoid implementation of the IMessage interface in the Nsb.Messages assembly
                config.Conventions().DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("Nsb") && t.Name.EndsWith("Message"));

                config.PurgeOnStartup(true);
                config.EnableInstallers();
                Bus = NServiceBus.Bus.Create(config).Start();
            }
        }
    }
}
