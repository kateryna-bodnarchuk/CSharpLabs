using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DomainModel
{
    public static class PersonSort
    {
        public static void Sort (List<Person> collection)
        {
            collection.Sort(PersonNameComparer.Instance);
        }


    }
}
