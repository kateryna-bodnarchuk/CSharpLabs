using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace DonorApplicationForm.ViewModels
{
    public sealed class AddPersonViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;

        public AddPersonViewModel()
        {
            this.BirthDate = new BirthDateViewModel();
            this.BloodGroup = new BloodGroupSelectionViewModel();
            this.Gender = new GenderSelectionViewModel();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(FirstName)));
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(LastName)));
                }
            }
        }

        public BirthDateViewModel BirthDate { get; set; }
        public GenderSelectionViewModel Gender { get; set; }
        public BloodGroupSelectionViewModel BloodGroup { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public event Action<Person> NewPerson;

        public void Add(object sender, RoutedEventArgs e)
        {
            var newPerson = new Person(
                firstName: this.firstName, 
                lastName: this.lastName, 
                birthDate: this.BirthDate.Date, 
                gender: this.Gender.ItemSelected.Value, 
                group: this.BloodGroup.ItemSelected.Value);

            if (NewPerson != null)
            {
                NewPerson(newPerson);
            }

            this.FirstName = string.Empty;
            this.LastName = string.Empty;
        }
    }
}
