using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    public sealed class ApplicationViewModel : INotifyPropertyChanged
    {
        public ApplicationViewModel()
        {
            this.AddPerson = new AddPersonViewModel();
            this.AddPerson.NewPerson += OnNewPerson;

            this.Items = new ObservableCollection<PersonViewModel>();
        }

        private void OnNewPerson(Person person)
        {
            var newPersonViewModel = new PersonViewModel(person);
            this.Items.Add(newPersonViewModel);
        }

        public AddPersonViewModel AddPerson { get; }

        public ObservableCollection<PersonViewModel> Items { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
