using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DataAccess
{
    internal static class GenderPersistance
    {
        public static int GenderCode(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:return 1;
                case Gender.Female: return 2;
                default:
                    throw new NotSupportedException();
            }
        }

        public static Gender GenderEnum(int code)
        {
            switch (code)
            {
                case 1: return Gender.Male;
                case 2: return Gender.Female;
                default:
                    throw new NotSupportedException();
            }
        }
            
    }
}
