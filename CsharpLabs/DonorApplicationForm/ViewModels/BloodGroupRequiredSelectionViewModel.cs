using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    public sealed class BloodGroupRequiredSelectionViewModel : INotifyPropertyChanged
    {
        private BloodGroupRequiredViewModel itemSelected;

        public BloodGroupRequiredSelectionViewModel()
        {
            this.ItemList = BloodGroupPresentationLogic
                .GetAllTitles()
                .Select(i => new BloodGroupRequiredViewModel(i.title, i.group))
                .ToList();

            var mostPopularGroupFroUserSelection = BloodGroup.II;
            this.itemSelected = ItemList
                .Where(i => i.Value == mostPopularGroupFroUserSelection)
                .Single();
        }

        public IReadOnlyCollection<BloodGroupRequiredViewModel> ItemList { get; }

        public BloodGroupRequiredViewModel ItemSelected
        {
            get { return this.itemSelected; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (this.itemSelected == value)
                {
                    return;
                }

                this.itemSelected = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
