using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DomainModel
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public Gender Gender { get; set; }
        public BloodGroup Group { get; set; }

        public Person(
            string firstName, 
            string lastName,
            DateTimeOffset birthDate,
            Gender gender, 
            BloodGroup group)
        {
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
