using NameSorter.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    public class ConsoleNamesWriter : INamesWriter
    {
        public void WriteNames(Stream dataStream)
        {
            using (StreamReader reader = new StreamReader(dataStream))
            {
                while (reader.Peek() >= 0)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }
    }
}
