using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Data
{
    public class Names
    {
        public string FirstName { get; set; }
        //ussually this is beside the last name required for identifications
        public string LastName { get; set; }
        //any extra given name can be placed here like those royalty with many names or 
        //knight or whatever
        public string[] GivenName { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FirstName +" ");
            foreach (var item in GivenName)
            {
                sb.Append(item + " ");
            }

            sb.Append(LastName);

            return sb.ToString();
        }

    }
}
