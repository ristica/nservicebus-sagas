# Microservices with NServiceBus and Saga

No need for any kind of database because everything happens in memory...

Just build the solution (restore all nuget packages) and set multiple starting projects:

- Nsb.Client (website)
- Nsb.Dispatch (the dispatcher of the orders)
- Nsb.PriceCalc (request/response pattern, representing synchronous communication)
- Nsb.Saga (coordinates the workflow)
- Nsb.Sales (simulates some kind of a sales departemnt)

IMPORTANT: MSMQ (under Windows features activate / deactivate) should be activated!

That's it!
