using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGraphData
    {
        int Id { get; }
        int PointX { get; }
        int PointY { get; }
    }
}
