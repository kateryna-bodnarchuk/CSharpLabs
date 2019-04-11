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
            PersonViewModel newPersonViewModel = NewPersonViewModel(person);
            this.items.Add(newPersonViewModel);

            OnItemsChanged();
        }

        private PersonViewModel NewPersonViewModel(Person person)
        {
            var model = new PersonViewModel(person);
            model.Removing += new Action<PersonViewModel>(OnItemRemoving);
            return model;
        }

        private void OnItemRemoving(PersonViewModel item)
        {
            this.items.Remove(item);
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

            if (this.NameFilter.Trim().Length > 0)
            {
                string nameFilterTrimmed = this.NameFilter.Trim();
                source = source.Where(
                    i =>
                        i.Data.FirstName.Contains(nameFilterTrimmed)
                        ||
                        i.Data.LastName.Contains(nameFilterTrimmed)
                );
            }

            BloodGroup? bloodGroupFilter = this.BloodGroupFilter.GetValue();
            if (bloodGroupFilter.HasValue)
            {
                source = source.Where(i => i.Data.Group == bloodGroupFilter.Value);
            }

            return source.OrderBy(i => i.Data.FirstName).ThenBy(i => i.Data.LastName);
        }
    }
}
