using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace DonorApplicationForm.ViewModels.DonorsListModels.Donations
{
    public sealed class AddDonationViewModel
    {
        public AddDonationViewModel()
        {
            At = DateTimeOffset.Now;
            Mililiters = 100.ToString();
        }
        public DateTimeOffset At { get; set; }
        public string Mililiters { get; set; }

        public event Action<Donation> NewDonation;

        public void Add(object sender, RoutedEventArgs e)
        {
            var result = new Donation(At.DateTime, double.Parse(Mililiters));

            if (NewDonation != null)
            {
                NewDonation(result);
            }
        }

    }
}
