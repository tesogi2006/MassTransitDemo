using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace MassTransitDemo
{
    public class SampleMessage : ISampleMessage
    {
        public string What { get; set; }
        public DateTime When { get; set; }
    }
}
