using System;
using System.Data.SqlClient;
using System.Linq;

namespace PROBLEM_8_IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string connectionString = @"Server=DESKTOP-B3I8JPR\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string sqlQuery = @"UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id";


                foreach (var item in ids)
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", item);
                        sqlCommand.ExecuteNonQuery();
                    }
                }

                string query = "SELECT Name, Age FROM Minions";
                using (SqlCommand sqlCommand = new SqlCommand(query,sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine($"{sqlDataReader[0]} {sqlDataReader[1]}");
                        }
                    }
                }

            }
        }
    }
}
//UPDATE Minions
//   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
// WHERE Id = @Id