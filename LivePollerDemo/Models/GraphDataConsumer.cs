using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using MassTransit;

namespace LivePollerDemo.Models
{
    public class GraphDataConsumer : IConsumer<IGraphData>
    {
        public static readonly Queue<IGraphData> Data = new Queue<IGraphData>(); 
        public Task Consume(ConsumeContext<IGraphData> context)
        {
            var data = context.Message;

            System.Console.WriteLine("New Data Point: [{0}, {1}]", data.PointX, data.PointY);

            Data.Enqueue(data);

            return Task.FromResult(0);
        }
    }
}