using NameSorter.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    public class NamesReader : INamesReader
    {
        public Stream Read(string path)
        {
            //plain converting file content into stream of data
            return new FileStream(path, FileMode.Open);
        }
    }
}
