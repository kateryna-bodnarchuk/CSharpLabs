using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonorApplicationForm.DomainModel;

namespace DonorApplicationForm.ViewModels
{
    public sealed class DonorsListViewModel : INotifyPropertyChanged
    {
        private List<PersonViewModel> items;
        private string nameFilter = string.Empty;

        public DonorsListViewModel()
        {
            this.items = new List<PersonViewModel>();
            this.BloodGroupFilter = new BloodGroupOptionalSelectionViewModel();
            this.BloodGroupFilter.ItemSelectedChanged += OnItemsChanged;
        }

        public IEnumerable<PersonViewModel> Items
        {
            get
            {
                return GetFilteredList();
            }
        }

        public int Count { get { return GetFilteredList().Count(); } }

        public string NameFilter
        {
            get { return this.nameFilter; }
            set
            {
                if (this.nameFilter == value) return;

                this.nameFilter = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(NameFilter)));
                }

                OnItemsChanged();
            }
        }

        public BloodGroupOptionalSelectionViewModel BloodGroupFilter { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void Add(Person person)
        {
            var newPersonViewModel = new PersonViewModel(person);
            this.items.Add(newPersonViewModel);

            OnItemsChanged();
        }

        private void OnItemsChanged()
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Items)));
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        private IEnumerable<PersonViewModel> GetFilteredList()
        {
            IEnumerable<PersonViewModel> source = this.items;

            if (!string.IsNullOrWhiteSpace(this.NameFilter))
            {
                string nameFilterTrimmed = this.NameFilter.Trim();
                source = source.Where(
                    i =>
                        i.Data.FirstName.Contains(nameFilterTrimmed)
                        ||
                        i.Data.LastName.Contains(nameFilterTrimmed)
                );
            }

            BloodGroup? bloodBroupFilter = this.BloodGroupFilter.GetValue();
            if (bloodBroupFilter.HasValue)
            {
                source = source.Where(i => i.Data.Group == bloodBroupFilter.Value);
            }

            return source.OrderBy(i => i.Data.FirstName).ThenBy(i => i.Data.LastName);
        }
    }
}
