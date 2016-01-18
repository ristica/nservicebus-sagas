using System;
using System.Web.Mvc;
using Nsb.Commands;
using Nsb.Infrastructure;
using Nsb.Messages;
using NServiceBus;
using Order = Nsb.Client.Models.Order;

namespace Nsb.Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Order order)
        {
            // do Request / Response for total price
            var callback = ServiceBus.Bus.Send(
                new PriceRequest
                {
                    Count = order.Count,
                    Price = order.Price
                }).
                Register(result =>
                {
                    var localResult = (CompletionResult) result.AsyncState;
                    var reply = (PriceResponse) localResult.Messages[0];
                    order.Price = reply.Total;
                }, null);
            callback.AsyncWaitHandle.WaitOne();

            return View("Review", order);
        }

        public ActionResult Confirm(Order order)
        {
            ServiceBus.Bus.Send(
                new ProcessOrderCommand
                {
                    OrderId = Guid.NewGuid(),
                    Article = order.Article,
                    Description = order.Description,
                    Count = order.Count,
                    Total = order.Price
                });

            return View("Success");
        }
    }
}