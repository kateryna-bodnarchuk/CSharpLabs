using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    /// <summary>
    /// Презентаційна модель аналогічна до <see cref="BloodGroupRequiredViewModel"/>
    /// за винятком того, що група крові дозволяє нул.
    /// </summary>
    public sealed class BloodGroupOptionalViewModel
    {
        public BloodGroupOptionalViewModel(string title, BloodGroup? value)
        {
            this.Title = title;
            this.Value = value;
        }

        public string Title { get; }

        internal BloodGroup? Value { get; }

    }
}
