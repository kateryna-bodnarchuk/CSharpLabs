using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonorApplicationForm.DataAccess.EntityFramework;
using DonorApplicationForm.DomainModel;

namespace DonorApplicationForm.DataAccess
{
    public sealed class DonationRepositoryEf : IDonationRepository
    {
        public void Add(Guid personId, DomainModel.Donation record)
        {
            using (var db = new BloodBankDbContext())
            {
                db.Donation.Add(
                    new EntityFramework.Donation
                    {
                        PersonId = personId,
                        At = record.At,
                        Milliliters = record.Milliliters,
                    });
                db.SaveChanges();
            }
        }

        public List<DomainModel.Donation> GetDonorRecords(Guid personId)
        {
            using (var db = new BloodBankDbContext())
            {
                return db.Donation.Where(i => i.PersonId == personId)
                    .Select(i => new { i.At, i.Milliliters })
                    .AsEnumerable()
                    .Select(i => new DomainModel.Donation(i.At, i.Milliliters))
                    .ToList();
            }
        }

        public void RemoveByPerson(Guid personId)
        {
            using (var db = new BloodBankDbContext())
            {
                var recordsToRemove = db.Donation.Where(i => i.PersonId == personId).ToList();
                foreach (var item in recordsToRemove)
                {
                    db.Donation.Remove(item);
                }
                db.SaveChanges();
            }
        }

        public void RemoveByPersonAt(Guid personId, DateTime at)
        {
            using (var db = new BloodBankDbContext())
            {
                var row = db.Donation.Where(i => i.PersonId == personId && i.At == at).Single();
                db.Donation.Remove(row);
                db.SaveChanges();
            }
        }
    }
}
