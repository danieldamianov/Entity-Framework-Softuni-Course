using System;
using System.Data.SqlClient;
using System.Text;

namespace PROBLEM_3_Minion_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            string connectionString = @"Server=DESKTOP-B3I8JPR\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";
            StringBuilder stringBuilder = new StringBuilder();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read() == false)
                        {
                            Console.WriteLine("No villain with ID 10 exists in the database.");
                            return;
                        }
                        else
                        {
                            stringBuilder.AppendLine($"Villain: {sqlDataReader["Name"]}");
                        }
                    }
                }
                using (SqlCommand sqlCommandTakeMinions = new SqlCommand(@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name,
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name", sqlConnection))
                {
                    sqlCommandTakeMinions.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader sqlDataReaderOfMinions = sqlCommandTakeMinions.ExecuteReader())
                    {
                        bool thereAreMs = false;
                        while (sqlDataReaderOfMinions.Read())
                        {
                            thereAreMs = true;
                            stringBuilder.AppendLine
                                ($"{sqlDataReaderOfMinions["RowNum"]}. " +
                                $"{sqlDataReaderOfMinions["Name"]} {sqlDataReaderOfMinions["Age"]}");
                        }
                        if (thereAreMs == false)
                        {
                            stringBuilder.AppendLine("(no minions)");
                        }
                    }
                }
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}

