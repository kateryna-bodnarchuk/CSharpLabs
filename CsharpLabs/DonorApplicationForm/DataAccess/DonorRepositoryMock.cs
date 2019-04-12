using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonorApplicationForm.DomainModel;

namespace DonorApplicationForm.DataAccess
{
    public sealed class DonorRepositoryMock : IDonorRepository
    {
        private readonly List<Person> items = new List<Person>()
        {
            new Person(
                Guid.NewGuid(),"Anna", "Bilyk", 
                new DateTimeOffset(1999, 7, 25, 0, 0, 0, TimeSpan.Zero), 
                Gender.Female, BloodGroup.I),
            new Person(
                Guid.NewGuid(),"Irina", "Bilyk",
                new DateTimeOffset(1985, 6, 30, 0, 0, 0, TimeSpan.Zero),
                Gender.Female, BloodGroup.II),
            new Person(
                Guid.NewGuid(),"Nick", "Jakson",
                new DateTimeOffset(1972, 1, 1, 0, 0, 0, TimeSpan.Zero),
                Gender.Male, BloodGroup.IV)
        };

        public void AddPerson(Person person)
        {
            items.Add(
                new Person(person.Id, person.FirstName, person.LastName, person.BirthDate, person.Gender, person.Group)
                );
        }

        public List<Person> GetPersonList()
        {
            return items;
        }

        public void Remove(Guid personId)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == personId)
                {
                    items.RemoveAt(i);
                    return;
                }
            }
        }

        public void Rename(Guid personId, string fistName, string lastName)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                if (item.Id == personId)
                {
                    item.FirstName = fistName;
                    item.LastName = lastName;
                    return;
                }
            }
        }
    }
}
