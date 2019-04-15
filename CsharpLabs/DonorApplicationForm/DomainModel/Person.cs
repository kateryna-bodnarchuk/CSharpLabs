using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DomainModel
{
    public class Person : IPerson
    {
        public Guid PersonId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public Gender Gender { get; set; }
        public BloodGroup Group { get; set; }


        public Person(
            Guid personId,
            string firstName, 
            string lastName,
            DateTimeOffset birthDate,
            Gender gender, 
            BloodGroup group)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            Group = group;
        }

        public int Age
        {
            get
            {
                return DateTimeOffset.Now.Year - this.BirthDate.Year;
            }
        }
    }
}
