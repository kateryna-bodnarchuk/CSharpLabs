using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonorApplicationForm.DomainModel;

namespace DonorApplicationForm.DataAccess
{
    public sealed class PersonRepository : IPersonRepository
    {

        public void AddPerson(Person person)
        {
            using(var connection = BloodBankDbConnection.NewConnectionOpened())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO Person(PersonId, FirstName, LastName, Gender, BloodGroup, BirthDate) VALUES (@PersonId, @FirstName, @LastName, @Gender, @BloodGroup, @BirthDate)";
                    command.Parameters.AddWithValue("@PersonId", person.PersonId);
                    command.Parameters.AddWithValue("@FirstName", person.FirstName);
                    command.Parameters.AddWithValue("@LastName", person.LastName);
                    command.Parameters.AddWithValue("@Gender", GenderPersistance.GenderCode(person.Gender));
                    command.Parameters.AddWithValue("@BloodGroup", BloodGroupPersistance.BloodGroupCode(person.Group));
                    command.Parameters.AddWithValue("@BirthDate", person.BirthDate);

                    command.ExecuteNonQuery();
                }

            }
        }

        public List<Person> GetPersonList()
        {
            var result = new List<Person>();
            using (var connection = BloodBankDbConnection.NewConnectionOpened())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select PersonId, FirstName, LastName, Gender, BloodGroup, BirthDate from Person";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid personId = (Guid)reader["PersonId"];
                            string firstName = (string)reader["FirstName"];
                            string lastName = (string)reader["LastName"];
                            int genderCode = (int)reader["Gender"];
                            int bloodGroupCode = (int)reader["BloodGroup"];
                            DateTime birthDate = (DateTime)reader["BirthDate"];
                            var person = new Person(
                                personId,
                                firstName,
                                lastName,
                                birthDate,
                                GenderPersistance.GenderEnum(genderCode),
                                BloodGroupPersistance.BloodGroupEnum(bloodGroupCode)
                                );
                            result.Add(person);
                        }
                    }
                }

            }

            return result;
        }

        public void Remove(Guid personId)
        {
            using (var connection = BloodBankDbConnection.NewConnectionOpened())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"DELETE FROM Person WHERE PersonId = @PersonId";
                    command.Parameters.AddWithValue("@PersonId", personId);

                    command.ExecuteNonQuery();
                }

            }
        }

        public void Rename(Guid personId, string fistName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
