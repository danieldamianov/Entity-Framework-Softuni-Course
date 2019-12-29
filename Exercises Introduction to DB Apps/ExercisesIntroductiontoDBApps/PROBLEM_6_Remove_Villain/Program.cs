using System;
using System.Data.SqlClient;

namespace PROBLEM_6_Remove_Villain
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            string connectionString = @"Server=DESKTOP-B3I8JPR\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                bool villainExists = CheckIfVillainExists(sqlConnection, villainId);

                if (villainExists == false)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                string outputForMinsReleased = ReleaseMinions(sqlConnection,villainId);
                string outputForVillainDeleted = DeleteVillain(sqlConnection, villainId);

                Console.WriteLine(outputForVillainDeleted);
                Console.WriteLine(outputForMinsReleased);
            }
        }

        private static string DeleteVillain(SqlConnection sqlConnection, int villainId)
        {
            string sqlQueryForDeletingVillain = @"DELETE FROM Villains
      WHERE Id = @villainId";

            using (SqlCommand sqlCommand = new SqlCommand(sqlQueryForDeletingVillain, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                string villainName = GetVillainNameById(sqlConnection, villainId);
                sqlCommand.ExecuteNonQuery();
                return $"{villainName} was deleted.";
            }
        }

        private static string GetVillainNameById(SqlConnection sqlConnection, int villainId)
        {
            string queryForCheckongVillainExistance = @"SELECT Name FROM Villains WHERE Id = @villainId";
            using (SqlCommand sqlCommand = new SqlCommand(queryForCheckongVillainExistance,sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("villainId", villainId);
                return (string)sqlCommand.ExecuteScalar();
               
            }
        }

        private static string ReleaseMinions(SqlConnection sqlConnection, int villainId)
        {
            string sqlQueryForReleasinMinions = @"DELETE FROM MinionsVillains
      WHERE VillainId = @villainId";
            using (SqlCommand sqlCommand = new SqlCommand(sqlQueryForReleasinMinions,sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                int minsDeleted = sqlCommand.ExecuteNonQuery();
                return $"{minsDeleted} minions were released.";
            }
        }

        private static bool CheckIfVillainExists(SqlConnection sqlConnection, int villainId)
        {
            string queryForCheckongVillainExistance = @"SELECT Name FROM Villains WHERE Id = @villainId";
            using (SqlCommand sqlCommand = new SqlCommand(queryForCheckongVillainExistance, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("villainId", villainId);
                object nameAsObj = sqlCommand.ExecuteScalar();
                if (nameAsObj == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}