using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    public sealed class GenderViewModel : INotifyPropertyChanged
    {
        public GenderViewModel(string title, Gender value)
        {
            this.Title = title;
            this.Value = value;
        }

        public string Title { get; }

        internal Gender Value { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
