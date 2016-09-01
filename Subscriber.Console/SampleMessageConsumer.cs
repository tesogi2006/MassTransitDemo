using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using MassTransit;

namespace Subscriber.Console
{
    public class SampleMessageConsumer : IConsumer<ISampleMessage>
    {
        public Task Consume(ConsumeContext<ISampleMessage> context)
        {
            System.Console.Write("Text: {0}", context.Message.What);
            System.Console.Write(" | Sent: {0}", context.Message.When);
            System.Console.Write(" | Processed: {0}", DateTime.Now);
            System.Console.WriteLine(" ({0})", System.Threading.Thread.CurrentThread.ManagedThreadId);

            /*
             * The Consume method is meant to be asynchronous, so it returns a Task. In this example, we aren’t making any other asynchronous calls, 
             * so we just use the Task.FromResult() helper method to return a Task with a zero result. If you were doing something asynchronous in 
             * the Consume method you could use async/await:
             * 
             * public async Task Consume(ConsumeContext<SomethingHappened> context)
             * {
             *      await SomeAsynchronousMethod(context.Message);
             * }
             * 
             */
            return Task.FromResult(0);
        }
    }
}
