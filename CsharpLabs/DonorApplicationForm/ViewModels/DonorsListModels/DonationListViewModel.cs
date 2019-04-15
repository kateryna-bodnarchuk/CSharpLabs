using DonorApplicationForm.DomainModel;
using DonorApplicationForm.ViewModels.DonorsListModels;
using System;
using System.Collections.Generic;

namespace DonorApplicationForm.ViewModels
{
    /// <summary>
    /// Agregates donations by person and provides its editing.
    /// </summary>
    public class DonationListViewModel
    {
        private readonly Guid personId;

        public DonationListViewModel(Guid personId)
        {
            this.AddForm = new AddDonorRecordViewModel();
            this.AddForm.NewDonation += new Action<DonationRecord>(OnNewDonation);
            this.personId = personId;
            this.Items = new List<DonationViewModel>
            {
                new DonationViewModel(),
                new DonationViewModel(),
            };
        }

        public AddDonorRecordViewModel AddForm { get; }
        public List<DonationViewModel> Items { get; }

        private void OnNewDonation(DonationRecord record)
        {

        }
    }
}