# NServiceBus-Saga
Microservices with NServiceBus and Sagas

No need for any kind of database because everything happens in mmemory...

Just build solution (restore all nuget packages) and set multiple starting projects:
- Nsb.Client (website)
- Nsb.Dispatch (the dispatcher of the orders)
- Nsb.PriceCalc (simulates some kind of service call)
- Nsb.Saga (coordinates the workflow)
- Nsb.Sales (simulates some kind of a sales departemnt)

That's it!
