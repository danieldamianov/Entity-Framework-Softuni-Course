using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PROBLEM_2_Villain_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-B3I8JPR\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";
            IList<VilinsMinionsCount> list = new List<VilinsMinionsCount>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(" SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  " +
                    "FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                    "GROUP BY v.Id, v.Name " +
                    "HAVING COUNT(mv.VillainId) > 3 " +
                    "ORDER BY COUNT(mv.VillainId)",sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            list.Add(new VilinsMinionsCount((string)sqlDataReader["Name"], (int)sqlDataReader["MinionsCount"]));
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine,list));
            
        }
    }
}
