using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonorApplicationForm.DomainModel;

namespace DonorApplicationForm.DataAccess
{
    public sealed class DonationRepositoryAdo : IDonationRepository
    {
        public void Add(Guid personId, Donation record)
        {
            using (var connection = BloodBankDbConnection.NewConnectionOpened())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO Donation(PersonId, At, Milliliters) VALUES (@PersonId, @At, @Milliliters)";
                    command.Parameters.AddWithValue("@PersonId", personId);
                    command.Parameters.AddWithValue("@At", record.At);
                    command.Parameters.AddWithValue("@Milliliters", record.Milliliters);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Donation> GetDonorRecords(Guid personId)
        {
            var result = new List<Donation>();
            using (var connection = BloodBankDbConnection.NewConnectionOpened())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select At, Milliliters FROM Donation WHERE PersonId = @PersonId";
                    command.Parameters.AddWithValue("@PersonId", personId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime at = (DateTime)reader["At"];
                            double milliliters = (double)reader["Milliliters"];
                            result.Add(new Donation(at, milliliters));
                        }
                    }
                }
            }

            return result;
        }

        public void RemoveByPersonAt(Guid personId, DateTime at)
        {
            using (var connection = BloodBankDbConnection.NewConnectionOpened())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"DELETE FROM Donation WHERE PersonId = @PersonId AND At = @At";
                    command.Parameters.AddWithValue("@PersonId", personId);
                    command.Parameters.AddWithValue("@At", at);

                    command.ExecuteNonQuery();
                }

            }
        }

        public void RemoveByPerson(Guid personId)
        {
            using (var connection = BloodBankDbConnection.NewConnectionOpened())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"DELETE FROM Donation WHERE PersonId = @PersonId";
                    command.Parameters.AddWithValue("@PersonId", personId);

                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
