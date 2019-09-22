using NameSorter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Contracts
{
    public interface INamesResolver
    {
        Names ExtractName(string text);
    }
}
