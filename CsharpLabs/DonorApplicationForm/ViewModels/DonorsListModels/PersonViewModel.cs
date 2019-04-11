using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel(Person person)
        {
            this.Data = person;
        }

        internal Person Data { get; }

        public string Title
        {
            get
            {
                return $"{this.Data.FirstName} {Data.LastName} | Group: {this.Data.Group.ToString()}";
            }
        }
    }
}
