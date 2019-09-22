using System;
using System.Threading.Tasks;

namespace NameSorter
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Please enter the file path and name to be sort!");
                return 1;
            }

            foreach (var arg in args)
            {
                var reader = new NamesFileReader();
                var readerStream = reader.Read(arg);
            }

            Console.Write("Press Enter key to exit");
            Console.ReadLine();
            return 0;

        }
    }
}
