using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonorApplicationForm.DataAccess.EntityFramework;
using DonorApplicationForm.DomainModel;

namespace DonorApplicationForm.DataAccess
{
    public sealed class PersonRepositoryEf : IPersonRepository
    {
        public void AddPerson(DomainModel.Person person)
        {
            using (var db = new BloodBankDbContext())
            {
                db.Person.Add(
                    new EntityFramework.Person
                    {
                        PersonId = person.PersonId,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Gender = GenderPersistance.GenderCode(person.Gender),
                        BloodGroup = BloodGroupPersistance.BloodGroupCode(person.Group),
                        BirthDate = person.BirthDate,
                    });
                db.SaveChanges();
            }
        }

        public List<DomainModel.Person> GetPersonList()
        {
            using (var db = new BloodBankDbContext())
            {
                return db.Person.AsEnumerable()
                    .Select(
                        i => new DomainModel.Person(
                            personId: i.PersonId,
                            firstName: i.FirstName,
                            lastName: i.LastName,
                            birthDate: i.BirthDate,
                            gender: GenderPersistance.GenderEnum(i.Gender),
                            group: BloodGroupPersistance.BloodGroupEnum(i.BloodGroup)
                        )
                    )
                    .ToList();
            }
        }

        public void Remove(Guid personId)
        {
            using (var db = new BloodBankDbContext())
            {
                var row = db.Person.Where(i => i.PersonId == personId).Single();
                db.Person.Remove(row);
                db.SaveChanges();
            }
        }

        public void Rename(Guid personId, string fistName, string lastName)
        {
            using (var db = new BloodBankDbContext())
            {
                var row = db.Person.Where(i => i.PersonId == personId).Single();
                row.FirstName = fistName;
                row.LastName = lastName;
                db.SaveChanges();
            }
        }
    }
}
