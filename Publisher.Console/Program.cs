using System;
using System.Configuration;
using Contracts;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;

namespace Publisher.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogger.Use();
            var uri = ConfigurationManager.AppSettings["massTransitUri"];
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
                x.Host(new Uri(uri), h => { })
                );
            var rand = new Random(1);

            var busHandle = bus.Start();
            var text = "";

            while (text != "quit")
            {
                System.Console.Write("Enter Message: [Press ENTER] ");
                text = System.Console.ReadLine();

                var msg = new SampleMessage()
                {
                    What = text,
                    When = DateTime.Now
                };

                var data = new GraphData()
                {
                    PointX = rand.Next(1, 1000),
                    PointY = rand.Next(1, 1000)
                };
                System.Console.WriteLine("Published Data: [{0}, {1}]", data.PointX, data.PointY);
                //bus.Publish<ISampleMessage>(msg);
                bus.Publish<IGraphData>(data);
            }

            busHandle.Stop();
        }
    }
}
