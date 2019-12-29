using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PROBLEM_5_Change_Town_Names_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-B3I8JPR\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";
            string countryName = Console.ReadLine();
            int countOfTownsAffected = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string sqlQueryForUpdatingTowns = @"UPDATE Towns
                                                    SET Name = UPPER(Name)
                                        WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQueryForUpdatingTowns, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@countryName", countryName);
                    countOfTownsAffected = sqlCommand.ExecuteNonQuery();
                }

                if (countOfTownsAffected == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                Console.WriteLine($"{countOfTownsAffected} town names were affected.");

                string sqlQueryForSelectingTownNames = @"SELECT t.Name
                                                                FROM Towns as t
                                                        JOIN Countries AS c ON c.Id = t.CountryCode
                                                                    WHERE c.Name = @countryName";

                List<string> townNames = new List<string>();

                using (SqlCommand sqlCommand = new SqlCommand(sqlQueryForSelectingTownNames, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@countryName", countryName);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            townNames.Add((string)sqlDataReader[0]);
                        }
                    }
                }

                Console.WriteLine($"[{string.Join(", ",townNames)}]");
            }


        }
    }
}
//UPDATE Towns
//   SET Name = UPPER(Name)
// WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)

//SELECT t.Name

//  FROM Towns as t
//  JOIN Countries AS c ON c.Id = t.CountryCode

// WHERE c.Name = @countryName