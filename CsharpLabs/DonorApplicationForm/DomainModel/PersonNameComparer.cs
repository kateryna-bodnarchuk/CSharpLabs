using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DomainModel
{
    public sealed class PersonNameComparer : IComparer<Person>
    {
        private PersonNameComparer() { }

        public static readonly IComparer<Person> Instance = new PersonNameComparer();

        public int Compare(Person x, Person y)
        {
            int c = x.FirstName.CompareTo(y.FirstName);
            if (c == 0) return x.LastName.CompareTo(y.LastName);
            else return c;

        }
    }
}
