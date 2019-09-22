using NameSorter.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    public class NamesWriter : INamesWriter
    {

        /// <summary>
        /// File path to be written into, file name included.
        /// </summary>
        public string FilePath { get; set; }
        public void WriteNames(Stream dataStream)
        {
            //converting stream data to file.
            using (var fs = new FileStream(FilePath, FileMode.Create))
            {
                using (dataStream )
                {
                    dataStream.CopyTo(fs);
                }
            }
        }
    }
}
