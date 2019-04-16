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
    public class PersonViewModel
    {
        public PersonViewModel(Person person)
        {
            this.Data = person;
            this.Donations = new DonationListViewModel(person.PersonId);
        }

        internal Person Data { get; }

        public string Title
        {
            get
            {
                return $"{this.Data.FirstName} {Data.LastName} | Group: {this.Data.Group.ToString()}";
            }
        }
        public DonationListViewModel Donations { get; }
        public event Action<PersonViewModel> Removing;

        public void Remove(object sender, RoutedEventArgs e)
        {
            if (Removing != null) Removing(this);
        }

    }
}
