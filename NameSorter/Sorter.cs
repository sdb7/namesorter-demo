using NameSorter.Contracts;
using NameSorter.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NameSorter
{
    public class Sorter
    {
        //temporal container
        List<Names>     _unsortedNames, 
                        _sortedNames;

        //source stream for processing.
        private Stream  _sourceStream;

        public INamesReader NamesReader { get; private set; }

        public Sorter(INamesReader namesReaderContract)
        {
            _unsortedNames = new List<Names>();
            _sortedNames = new List<Names>();

            NamesReader = namesReaderContract;
        }

        /// <summary>
        /// read from file source
        /// </summary>
        /// <param name="path"></param>
        public void ReadSource(string path)
        {
            _sourceStream = NamesReader.Read(path);

            using (StreamReader reader = new StreamReader(_sourceStream))
            {
                while (reader.Peek() >= 0)
                {
                    var str = reader.ReadLine();
                    Names currentName = SolveName(new NameSolver(), str);

                    //check if this names already exist within collections, entry if none exist.
                    //TODO :update if its not.
                    var isCurrentNameExist = _unsortedNames.Contains(currentName);
                    if (!isCurrentNameExist)
                        _unsortedNames.Add(currentName);

                }
            }
        }

        public IList<Names> Sort()
        {
            //give temporary data to debuggin purpose
            var sortedIenumerable = _unsortedNames.OrderBy(s => s.LastName)
                .ThenBy(s=>s.FirstName)
                .ThenBy(n=>n.GivenName);

            //this is bad example, worse code readability..but can't helped for now!.
            return _sortedNames = sortedIenumerable.ToList();
        }

        public void ShowResult(INamesWriter namesWriterContract)
        {
            foreach (var item in _sortedNames)
            {
                var content = new MemoryStream(Encoding.UTF8.GetBytes(item.ToString()));
                namesWriterContract.WriteNames(content);
            }
        }

        public Names SolveName(INamesResolver namesResolver, string text)
        {
            return namesResolver.ExtractName(text);
        }
    }
}
