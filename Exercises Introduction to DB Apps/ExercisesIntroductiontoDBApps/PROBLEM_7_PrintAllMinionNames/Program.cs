using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PROBLEM_7_PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-B3I8JPR\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                List<string> list = GetAllNames(sqlConnection);
                if (list.Count % 2 == 0)
                {
                    for (int i = 0; i <= list.Count / 2 - 1; i++)
                    {
                        int right = list.Count - 1 - i;
                        int left = i;
                        if (right < left)
                        {
                            break;
                        }
                        Console.WriteLine(list[left]);
                        Console.WriteLine(list[right]);
                    } 
                }
                else
                {
                    for (int i = 0; i <= list.Count / 2; i++)
                    {
                        int right = list.Count - 1 - i;
                        int left = i;
                        if (right == left)
                        {
                            Console.WriteLine(list[left]);
                            break;
                        }
                        Console.WriteLine(list[left]);
                        Console.WriteLine(list[right]);
                    }
                }
            }
        }

        private static List<string> GetAllNames(SqlConnection sqlConnection)
        {
            string queryForGettingAllNames = "SELECT Name FROM Minions";
            List<string> list = new List<string>();
            using (SqlCommand sqlCommand = new SqlCommand(queryForGettingAllNames,sqlConnection))
            {
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        list.Add((string)sqlDataReader[0]);
                    }
                }
            }
            return list;
        }
    }
}
