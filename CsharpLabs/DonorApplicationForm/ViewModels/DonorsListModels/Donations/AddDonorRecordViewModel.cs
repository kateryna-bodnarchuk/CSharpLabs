using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace DonorApplicationForm.ViewModels.DonorsListModels
{
    public sealed class AddDonorRecordViewModel
    {
        public AddDonorRecordViewModel()
        {
            At = DateTimeOffset.Now;
            Mililiters = 100.ToString();
        }
        public DateTimeOffset At { get; set; }
        public string Mililiters { get; set; }

        public event Action<DonationRecord> NewDonation;

        public void Add(object sender, RoutedEventArgs e)
        {
            //var result = new DonationRecord()
        }

    }
}
