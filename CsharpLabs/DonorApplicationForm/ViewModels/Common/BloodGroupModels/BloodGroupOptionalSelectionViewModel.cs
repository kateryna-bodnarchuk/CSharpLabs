using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels.Common.BloodGroupModels
{
    public sealed class BloodGroupOptionalSelectionViewModel
    {
        private BloodGroupOptionalViewModel itemSelected;

        public BloodGroupOptionalSelectionViewModel()
        {
            this.ItemList = new List<BloodGroupOptionalViewModel>();
            var allCase = new BloodGroupOptionalViewModel("-- All --", new Nullable<BloodGroup>());
            this.ItemList.Add(allCase);
            this.ItemList.AddRange(
                BloodGroupPresentationLogic
                .GetAllTitles()
                .Select(i => new BloodGroupOptionalViewModel(i.title, i.group))
            );

            this.itemSelected = allCase;
        }

        public List<BloodGroupOptionalViewModel> ItemList { get; }

        public BloodGroupOptionalViewModel ItemSelected
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

                if (this.ItemSelectedChanged != null)
                {
                    this.ItemSelectedChanged();
                }
            }
        }

        internal BloodGroup? GetValue()
        {
            return this.ItemSelected.Value;
        }

        public event Action ItemSelectedChanged;
    }
}
