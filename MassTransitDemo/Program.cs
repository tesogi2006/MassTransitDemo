﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;

namespace MassTransitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogger.Use();
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
                x.Host(new Uri("rabbitmq://localhost/habesha"), h => { })
                );

            var busHandle = bus.Start();
            var text = "";

            while (text != "quit")
            {
                System.Console.Write("Enter Message: ");
                text = System.Console.ReadLine();

                var msg = new SampleMessage()
                {
                    What = text,
                    When = DateTime.Now
                };

                bus.Publish<ISampleMessage>(msg);
            }

            busHandle.Stop();
        }
    }
}
