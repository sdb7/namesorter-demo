﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Contracts
{
    public interface INamesWriter
    {
        void WriteNames(Stream dataStream);
    }
}
