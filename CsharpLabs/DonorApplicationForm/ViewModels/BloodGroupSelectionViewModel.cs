using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    public sealed class BloodGroupSelectionViewModel : INotifyPropertyChanged
    {
        private BloodGroupViewModel itemSelected;

        public BloodGroupSelectionViewModel()
        {
            this.ItemList = new[]
            {
                new BloodGroupViewModel("I (First)", BloodGroup.I),
                new BloodGroupViewModel("II (Second)", BloodGroup.II),
                new BloodGroupViewModel("III (Third)", BloodGroup.III),
                new BloodGroupViewModel("IV (Fourth)", BloodGroup.IV),
            };

            var mostPopularGroupFroUserSelection = BloodGroup.II;
            this.itemSelected = ItemList
                .Where(i => i.Value == mostPopularGroupFroUserSelection)
                .Single();
        }

        public IReadOnlyCollection<BloodGroupViewModel> ItemList { get; }

        public BloodGroupViewModel ItemSelected
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
