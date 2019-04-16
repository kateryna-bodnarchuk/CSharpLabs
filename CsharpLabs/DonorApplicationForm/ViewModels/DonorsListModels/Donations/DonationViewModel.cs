using System;
using DonorApplicationForm.DomainModel;

namespace DonorApplicationForm.ViewModels
{
    public class DonationViewModel
    {
        public DonationViewModel(DonationRecord record)
        {
            this.Data = record;
            Title = record.At.ToString() + ", " + record.Ml.ToString() + " ml";
        }
        public string Title { get; }
        public DonationRecord Data;

        internal event Action<DonationViewModel> Removing;

    }


}