using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels.Common.BloodGroupModels
{
    public sealed class BloodGroupRequiredSelectionViewModel
    {
        private BloodGroupRequiredViewModel itemSelected;

        public BloodGroupRequiredSelectionViewModel()
        {
            this.ItemList = 
                BloodGroupPresentationLogic
                .GetAllTitles()
                .Select(i => new BloodGroupRequiredViewModel(i.title, i.group))
                .ToArray();

            var mostPopularGroupForUserSelection = BloodGroup.II;
            this.itemSelected = ItemList
                .Where(i => i.Value == mostPopularGroupForUserSelection)
                .Single();
        }

        public BloodGroupRequiredViewModel[] ItemList { get; }

        public BloodGroupRequiredViewModel ItemSelected
        {
            get { return this.itemSelected; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (!ItemList.Contains(value))
                {
                    throw new ArgumentException("Strange item passed.");
                }

                if (this.itemSelected == value)
                {
                    return;
                }

                this.itemSelected = value;
            }
        }
    }
}
