using DonorApplicationForm.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DataAccess
{
    interface IDonationRepository
    {
        List<Donation> GetDonorRecords(Guid personId);
        void Add(Guid personId, Donation record);
        void RemoveByPersonAt(Guid personId, DateTime at);
        void RemoveByPerson(Guid personId);
    }

}
