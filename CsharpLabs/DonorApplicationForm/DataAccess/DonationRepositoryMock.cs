using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonorApplicationForm.DomainModel;

namespace DonorApplicationForm.DataAccess
{
    class DonationRepositoryMock : IDonationRepository
    {
        private readonly List<DbRecord> items = new List<DbRecord>();

        public void Add(Guid personId, DonationRecord record)
        {
            this.items.Add(
                new DbRecord
                {
                    PersonId = personId,
                    At = record.At,
                    Ml = record.Milliliters,
                }
            );
        }

        public List<DonationRecord> GetDonorRecords(Guid personId)
        {
            return items.Where(i => i.PersonId == personId)
                .Select(r => new DonationRecord(r.At, r.Ml)).ToList();

        //    var result = new List<DonationRecord>();
        //    foreach (DbRecord r in items)
        //    {
        //        if (r.PersonId == personId)
        //        {
        //            result.Add(new DonationRecord(r.At, r.Ml));
        //        }
        //    }
        //    return result;
        }

        public void RemoveByPerson(Guid personId)
        {
            throw new NotImplementedException();
        }

        public void RemoveByPersonAt(Guid personId, DateTime at)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                var item = items[i];
                if (item.PersonId == personId && item.At == at)
                {
                    items.RemoveAt(i);
                    return;
                }
              
            }
        }

        private class DbRecord
        {
            public Guid PersonId { get; set; }
            public DateTime At { get; set; }
            public double Ml { get; set; }
        }
    }
}
