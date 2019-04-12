using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonorApplicationForm.DomainModel;

namespace DonorApplicationForm.DataAccess
{
    public sealed class DonorRepository : IDonorRepository
    {
        public void AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPersonList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid personId)
        {
            throw new NotImplementedException();
        }

        public void Rename(Guid personId, string fistName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
