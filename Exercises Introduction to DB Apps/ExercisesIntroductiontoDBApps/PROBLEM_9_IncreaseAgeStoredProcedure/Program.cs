using System;
using System.Data.SqlClient;

namespace PROBLEM_9_IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-B3I8JPR\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queryForCreatingTheProc = @"CREATE PROC usp_GetOlder @id INT
AS
UPDATE Minions
   SET Age += 1
 WHERE Id = @id";
                using (SqlCommand sqlCommand = new SqlCommand(queryForCreatingTheProc,sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }

                int id = int.Parse(Console.ReadLine());

                string queryForExecutingTheProc = @"EXEC usp_GetOlder @Id";
                using (SqlCommand sqlCommand = new SqlCommand(queryForExecutingTheProc,sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlCommand.ExecuteNonQuery();
                }

                string queryForGettingTheMinion = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
                using (SqlCommand sqlCommand = new SqlCommand(queryForGettingTheMinion, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        sqlDataReader.Read();
                        Console.WriteLine(sqlDataReader[0] + " " + sqlDataReader[1]);
                    }
                }
            }

            
        }
    }
}
