﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISampleMessage
    {
        string What { get; }
        DateTime When { get; }
    }
}
