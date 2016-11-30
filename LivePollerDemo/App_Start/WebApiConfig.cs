using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LivePollerDemo.Models;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;

namespace LivePollerDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Log4NetLogger.Use();
            MassTransitRun();

            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                 name: "ControllerWithAction",
                 routeTemplate: "api/{controller}/{action}"
             );
        }

        private static void MassTransitRun()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri("rabbitmq://localhost/habesha"), h => { });

                x.ReceiveEndpoint(host, "MassTransitDemo_WebSubscriber", e =>
                    e.Consumer<GraphDataConsumer>());
            });

            bus.StartAsync();
            //bus.Stop();
        }
    }
}
