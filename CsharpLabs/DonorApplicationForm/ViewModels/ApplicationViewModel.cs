using DonorApplicationForm.DomainModel;
using DonorApplicationForm.ViewModels.DonorsListModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    public sealed class ApplicationViewModel
    {
        public ApplicationViewModel()
        {
            this.AddPerson = new AddPersonViewModel();
            this.AddPerson.NewPerson += new Action<Person>(OnNewPerson);

            this.DonorsList = new PersonListViewModel();
        }

        private void OnNewPerson(Person person)
        {
            this.DonorsList.Add(person);
        }

        public AddPersonViewModel AddPerson { get; }

        public PersonListViewModel DonorsList { get; }
    }
}
