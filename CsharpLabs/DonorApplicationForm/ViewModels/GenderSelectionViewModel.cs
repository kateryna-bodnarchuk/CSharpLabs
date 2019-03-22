using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    public sealed class GenderSelectionViewModel : INotifyPropertyChanged
    {
        private GenderViewModel itemSelected;

        public GenderSelectionViewModel()
        {
            this.ItemList = new[]
            {
                new GenderViewModel("Male", Gender.Male),
                new GenderViewModel("Female", Gender.Female),
            };
            this.itemSelected = ItemList.First();
        }

        public IReadOnlyCollection<GenderViewModel> ItemList { get; }

        public GenderViewModel ItemSelected
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
