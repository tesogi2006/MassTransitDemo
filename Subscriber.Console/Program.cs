using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;

namespace Subscriber.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogger.Use();

            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri("rabbitmq://localhost/habesha"), h => { });

                x.ReceiveEndpoint(host, "MassTransitDemo_TestSubscriber", e =>
                    e.Consumer<SampleMessageConsumer>());
            });

            var busHandle = bus.Start();
            System.Console.ReadKey();

            busHandle.Stop();
        }
    }
}
