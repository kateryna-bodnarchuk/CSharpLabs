using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DomainModel
{
    public sealed class DonationRecord
    {
        public DateTime At { get; }
        public double Ml { get; }

        public DonationRecord(DateTime at, double ml)
        {
            At = at;
            Ml = ml;
        }
    }
}
