using NameSorter.Contracts;
using NameSorter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    public class NameSolver : INamesResolver
    {
        private Names _names;

        public Names ExtractName(string text)
        {
            //lets asume this text containe name and separate with space between name component.
            var nameSplitted = text.Trim().Split(new[] {' ' }, StringSplitOptions.RemoveEmptyEntries);
            _names = new Names {
                LastName = nameSplitted[nameSplitted.Length - 1],
                FirstName = nameSplitted[0],
                
                //this is felt as hacked, using regex will be most approriate, but we can't write a new regex 
                //every time someone had many name component and beside writing regex is time consuming and 
                //might not optimized and produce slow down
                GivenName = nameSplitted.Skip(1).Take(nameSplitted.Length -2).ToArray()
            };

            return _names;
        }
    }
}
