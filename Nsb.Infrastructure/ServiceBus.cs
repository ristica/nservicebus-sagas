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
                config.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("Nsb") && t.Name.EndsWith("Command"));
                config.PurgeOnStartup(true);
                config.EnableInstallers();
                Bus = NServiceBus.Bus.Create(config).Start();
            }
        }
    }
}
