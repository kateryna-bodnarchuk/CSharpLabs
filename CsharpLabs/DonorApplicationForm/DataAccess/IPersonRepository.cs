using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DataAccess
{
    public interface IPersonRepository
    {
        List<Person> GetPersonList();
        void AddPerson(Person person);
        void Remove(Guid personId);
        void Rename(Guid personId, string fistName, string lastName);
    }
}
