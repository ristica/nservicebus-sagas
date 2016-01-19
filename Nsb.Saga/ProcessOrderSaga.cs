using System;
using Nsb.Commands;
using Nsb.Messages;
using Nsb.Shared;
using NServiceBus;
using NServiceBus.Saga;

namespace Nsb.Saga
{
    public class ProcessOrderSaga : Saga<ProcessOrderSagaData>,
        IAmStartedByMessages<ProcessOrderCommand>,
        IHandleMessages<OrderPlannedMessage>,
        IHandleMessages<OrderDispatchedMessage>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ProcessOrderSagaData> mapper)
        {
            mapper.ConfigureMapping<ProcessOrderCommand>(msg => msg.OrderId).ToSaga(s => s.OrderId);
            mapper.ConfigureMapping<OrderPlannedMessage>(msg => msg.OrderId).ToSaga(s => s.OrderId);
            mapper.ConfigureMapping<OrderDispatchedMessage>(msg => msg.OrderId).ToSaga(s => s.OrderId);
        }

        public void Handle(ProcessOrderCommand message)
        {
            Console.WriteLine();
            Console.WriteLine("1) Saga: sending order {0} to Sales ...", message.OrderId);

            Data.OrderId = message.OrderId;
            Data.Article = message.Article;
            Data.Description = message.Description;
            Data.Count = message.Count;
            Data.Price = message.Total;
            Data.Address = "Fernkorngasse, 1100 Wien";

            Bus.Send(
                new AcceptOrderCommand
                {
                    OrderId = Data.OrderId,
                    Status = OrderStatus.Started
                });
        }

        public void Handle(OrderPlannedMessage message)
        {
            Console.WriteLine();
            Console.WriteLine("4) Order {0} accepted!", Data.OrderId);
            Console.WriteLine("5) Saga: sending order {0} to Dispatcher...", Data.OrderId);

            switch (message.Status)
            {
                case OrderStatus.Accepted:
                    Bus.Send(
                        new DispatchOrderCommand
                        {
                            OrderId = Data.OrderId,
                            Address = Data.Address
                        });
                    break;
                case OrderStatus.Failed:
                    // handle failed status here
                    // ...
                    break;
                default:
                    // handle other status here
                    // ...
                    break;
            }
        }

        public void Handle(OrderDispatchedMessage message)
        {
            Console.WriteLine();
            Console.WriteLine("8) Order {0} successfully dispatched!", Data.OrderId);
            Console.WriteLine("9) Saga: sending order {0} back to originator...", Data.OrderId);

            switch (message.Status)
            {
                case OrderStatus.Dispatched:
                    ReplyToOriginator(
                        new OrderProcessedMessage
                        {
                            OrderId = Data.OrderId,
                            Status = OrderStatus.Processed
                        });

                    MarkAsComplete();
                    Console.WriteLine("10) Saga with ID {0} successfully processed!", Data.OrderId);
                    break;
                case OrderStatus.Failed:
                    // handle failed status here
                    // ...
                    break;
                default:
                    // handle other status here
                    // ...
                    break;
            }
        }
    }
}
