using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Publisher.Console
{
    public class GraphData : IGraphData
    {
        public int Id { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
    }
}
