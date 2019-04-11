using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.ViewModels
{
    public static class BloodGroupPresentationLogic
    {
        public static IEnumerable<(string title, BloodGroup group)> GetAllTitles()
        {
            return new[]
            {
                ("I (First)", BloodGroup.I),
                ("II (Second)", BloodGroup.II),
                ("III (Third)", BloodGroup.III),
                ("IV (Fourth)", BloodGroup.IV),
            };
        }
    }
}
