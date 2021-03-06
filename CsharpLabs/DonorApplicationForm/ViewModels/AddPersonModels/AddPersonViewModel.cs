﻿using DonorApplicationForm.DomainModel;
using DonorApplicationForm.ViewModels.Common.BloodGroupModels;
using DonorApplicationForm.ViewModels.Common.GenderModels;
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
            this.BloodGroup = new BloodGroupRequiredSelectionViewModel();
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
        public BloodGroupRequiredSelectionViewModel BloodGroup { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<Person> newPerson;

        public event Action<Person> NewPerson
        {
            add
            {
                this.newPerson += value;
            }
            remove
            {
                this.newPerson -= value;
            }
        }

        public void Add(object sender, RoutedEventArgs e)
        {
            var newPerson = new Person(
                personId: Guid.NewGuid(),
                firstName: this.firstName, 
                lastName: this.lastName, 
                birthDate: this.BirthDate.Date.DateTime, 
                gender: this.Gender.ItemSelected.Value, 
                group: this.BloodGroup.ItemSelected.Value);

            if (this.newPerson != null)
            {
                this.newPerson.Invoke(newPerson);
            }

            this.FirstName = string.Empty;
            this.LastName = string.Empty;
        }
    }
}
