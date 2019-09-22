using System;
using System.IO;
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

            var path = args[0];
            //checking path
            var isFileExist = File.Exists(path);
            if (!isFileExist)
            {
                Console.WriteLine($"{path} not exist, please try another file");
                return 1;
            }
            else
            {
                try
                {
                    //testing if file at path is readable as text
                    var stream = File.ReadAllText(path);
                }
                catch (IOException ioException)
                {
                    Console.WriteLine($"{path}, reading error message :{ioException.Message}");
                    return 1;
                }
                //check if this is txtfile and content is readable..

                Sorter sorterRoutine = new Sorter(new NamesFileReader());
                sorterRoutine.ReadSource(path);
                sorterRoutine.Sort();
                sorterRoutine.ShowResult(new ConsoleNamesWriter());
            }


            Console.Write("Press Enter key to exit");
            Console.ReadLine();
            return 0;

        }
    }
}
