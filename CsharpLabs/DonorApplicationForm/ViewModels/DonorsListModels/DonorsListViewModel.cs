using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonorApplicationForm.DataAccess;
using DonorApplicationForm.DomainModel;
using Windows.UI.Xaml;

namespace DonorApplicationForm.ViewModels
{
    public sealed class DonorsListViewModel : INotifyPropertyChanged
    {
        private readonly IDonorRepository donorRepository;
        private string nameFilter = string.Empty;
        private List<PersonViewModel> itemsFiltered;
        private PersonViewModel itemSelected;

        public DonorsListViewModel()
        {
            this.donorRepository = new DonorRepositoryMock();
            this.BloodGroupFilter = new BloodGroupOptionalSelectionViewModel();
            this.BloodGroupFilter.ItemSelectedChanged += UpdateItemsFiltered;
            UpdateItemsFiltered();
        }

        public IEnumerable<PersonViewModel> Items
        {
            get
            {
                return itemsFiltered;
            }
        }

        public PersonViewModel ItemSelected
        {
            get
            {
                return itemSelected;
            }
            set
            {
                if (itemSelected == value) return;

                itemSelected = value;
                if(PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(ItemSelected)));
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(ItemSelectedVisibility)));
                }
            }
        }

        public Visibility ItemSelectedVisibility
        {
            get
            {
                if (itemSelected == null) return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }



        public int Count { get { return itemsFiltered.Count(); } }

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

                UpdateItemsFiltered();
            }
        }

        public BloodGroupOptionalSelectionViewModel BloodGroupFilter { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void Add(Person person)
        {
            this.donorRepository.AddPerson(person);

            UpdateItemsFiltered();
        }

        private PersonViewModel NewPersonViewModel(Person person)
        {
            var model = new PersonViewModel(person);
            model.Removing += new Action<PersonViewModel>(OnItemRemoving);
            return model;
        }

        private void OnItemRemoving(PersonViewModel item)
        {
            this.donorRepository.Remove(item.Data.PersonId);
            UpdateItemsFiltered();
        }

        private void UpdateItemsFiltered()
        {
            this.itemsFiltered = GetFilteredList().ToList();

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Items)));
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        private IEnumerable<PersonViewModel> GetFilteredList()
        {
            IEnumerable<PersonViewModel> source = this.donorRepository.GetPersonList()
                .Select(NewPersonViewModel);

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
