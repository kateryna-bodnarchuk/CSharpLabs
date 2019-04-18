using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DataAccess
{
    internal static class BloodGroupPersistance
    {
        public static int BloodGroupCode(BloodGroup bloodGroup)
        {
            switch (bloodGroup)
            {
                case BloodGroup.I: return 1;
                case BloodGroup.II: return 2;
                case BloodGroup.III: return 3;
                case BloodGroup.IV: return 4;

                default:
                    throw new NotSupportedException();
            }
        }

        public static BloodGroup BloodGroupEnum(int code)
        {
            switch (code)
            {
                case 1: return BloodGroup.I;
                case 2: return BloodGroup.II;
                case 3: return BloodGroup.III;
                case 4: return BloodGroup.IV;

                default:
                    throw new NotSupportedException();
            }
        }

    }
}
