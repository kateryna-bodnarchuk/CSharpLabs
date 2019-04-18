using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DataAccess
{
    public static class BloodBankDbConnection
    {
        public static readonly string ConnectionString = "Data Source=DESKTOP-M3MUJLC\\SQLEXPRESS;Initial Catalog=BloodBank;Integrated Security=SSPI";

        public static SqlConnection NewConnectionOpened()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
