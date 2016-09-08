using System;
using Contracts;

namespace Publisher.Console
{
    public class SampleMessage : ISampleMessage
    {
        public string What { get; set; }
        public DateTime When { get; set; }
    }
}
