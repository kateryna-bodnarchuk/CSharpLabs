using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    public sealed class BirthDateViewModel : INotifyPropertyChanged
    {
        private DateTimeOffset date;

        public BirthDateViewModel()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            this.MinValue = now.Subtract(TimeSpan.FromDays(365 * 150));
            this.MaxValue = now;
            this.date = MaxValue;
        }
       
        public DateTimeOffset MinValue { get; }

        public DateTimeOffset MaxValue { get; }

        public DateTimeOffset Date
        {
            get { return this.date; }
            set
            {
                if (value < this.MinValue || value > this.MaxValue)
                {
                    return;
                }

                this.date = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Date)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
