using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DomainModel
{
    public sealed class MonostatePerson : IPerson
    {
        private static int globalRenameCount = 0;

        private string firstName = string.Empty;

        private string lastName = string.Empty;

        public string FirstName
        {
            get { return firstName; }
            set {
                firstName = value;
                globalRenameCount++;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
