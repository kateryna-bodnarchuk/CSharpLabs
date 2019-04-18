using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels.Common.BloodGroupModels
{
    public sealed class BloodGroupRequiredViewModel : INotifyPropertyChanged
    {
        public BloodGroupRequiredViewModel(string title, BloodGroup value)
        {
            this.Title = title;
            this.Value = value;
        }

        public string Title { get; }

        internal BloodGroup Value { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
