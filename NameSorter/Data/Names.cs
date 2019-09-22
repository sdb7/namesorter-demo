using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Data
{
    public class Names : IComparable<Names>
    {
        public string FirstName { get; set; }
        //ussually this is beside the last name required for identifications
        public string LastName { get; set; }
        //any extra given name can be placed here like those royalty with many names or 
        //knight or whatever
        public string[] GivenName { get; set; }

        public int CompareTo(Names other)
        {
            //if compared to null.
            if (other == null)
                return 1;

            //array comparing
            if(this.GivenName.Length > other.GivenName.Length)
            {
                int[] compIndex = new int[other.GivenName.Length];

                for (int i = 0; i < other.GivenName.Length; i++)
                {
                    compIndex[i] = this.GivenName[i].CompareTo(other.GivenName[i]);
                }

                foreach (var item in compIndex)
                {
                    return item;
                }
            }

            if (this.GivenName.Length < other.GivenName.Length)
            {
                int[] compIndex = new int[other.GivenName.Length];

                for (int i = 0; i < this.GivenName.Length; i++)
                {
                    compIndex[i] = this.GivenName[i].CompareTo(other.GivenName[i]);
                }

                foreach (var item in compIndex)
                {
                    return item;
                }
            }

            if (this.GivenName.Length == other.GivenName.Length)
            {
                int[] compIndex = new int[other.GivenName.Length];

                for (int i = 0; i < other.GivenName.Length; i++)
                {
                    compIndex[i] = this.GivenName[i].CompareTo(other.GivenName[i]);
                }

                foreach (var item in compIndex)
                {
                    return item;
                }
            }

            return this.LastName.CompareTo(other.LastName);
        }

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
