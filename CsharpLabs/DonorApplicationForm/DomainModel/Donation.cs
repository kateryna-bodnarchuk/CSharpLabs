using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DomainModel
{
    public sealed class Donation
    {
        public DateTime At { get; }
        public double Milliliters { get; }

        public Donation(DateTime at, double ml)
        {
            At = at;
            Milliliters = ml;
        }
    }
}
