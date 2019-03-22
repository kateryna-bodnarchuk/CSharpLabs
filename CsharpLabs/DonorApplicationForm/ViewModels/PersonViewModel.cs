using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private readonly Person person;

        public PersonViewModel(Person person)
        {
            this.person = person;
            this.Age = new BirthDateViewModel();
            this.BloodGroup = new BloodGroupSelectionViewModel();
            this.Gender = new GenderSelectionViewModel();
        }

        public string FirstName
        {
            get
            {
                return this.person.FirstName;
            }
            set
            {
                this.person.FirstName = value;
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
                return this.person.LastName;
            }
            set
            {
                this.person.LastName = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(LastName)));
                }
            }
        }

        public BirthDateViewModel Age { get; set; }
        public GenderSelectionViewModel Gender { get; set; }
        public BloodGroupSelectionViewModel BloodGroup { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
