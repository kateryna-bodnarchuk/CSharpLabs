using DonorApplicationForm.DataAccess;
using DonorApplicationForm.DomainModel;
using DonorApplicationForm.ViewModels.DonorsListModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DonorApplicationForm.ViewModels
{
    /// <summary>
    /// Agregates donations by person and provides its editing.
    /// </summary>
    public class DonationListViewModel : INotifyPropertyChanged
    {
        private readonly Guid personId;
        private List<DonationViewModel> items;
        private readonly IDonationRepository donationRepository;
      
        public DonationListViewModel(Guid personId)
        {
            this.AddForm = new AddDonationViewModel();
            this.AddForm.NewDonation += new Action<Donation>(OnNewDonation);
            this.personId = personId;
            this.donationRepository = new DonationRepository();

            UpdateItems();
        }

        public AddDonationViewModel AddForm { get; }

        public List<DonationViewModel> Items => items;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNewDonation(Donation record)
        {
            this.donationRepository.Add(personId, record);
            UpdateItems();
        }

        private void UpdateItems()
        {
            this.items = this.donationRepository.GetDonorRecords(personId)
                .Select(NewDonationViewModel).ToList();
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Items)));
            }
        }

        private DonationViewModel NewDonationViewModel(Donation record)
        {
            var model = new DonationViewModel(record);
            model.Removing += new Action<DonationViewModel>(OnItemRemoving);
            return model;
        }

        private void OnItemRemoving(DonationViewModel item)
        {
            this.donationRepository.RemoveByPersonAt(personId, item.Data.At);
            UpdateItems();
        }
    }
}