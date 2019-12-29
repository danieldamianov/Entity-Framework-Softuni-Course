using System;
using System.Data.SqlClient;

namespace PROBLEM_4_Add_Minion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            string minionName = input[1];
            int minionAge = int.Parse(input[2]);
            string minionTownName = input[3];
            int townId = -1;
            int evilId = -1;
            int minionId = -1;

            input = Console.ReadLine().Split(' ');
            string vilianName = input[1];

            string connectionString = @"Server=DESKTOP-B3I8JPR\SQLEXPRESS;Database=MinionsDB;Integrated Security = true";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT Id FROM Towns WHERE Name = @townName", sqlConnection)) 
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@townName", minionTownName));
                    object townIdInObject = sqlCommand.ExecuteScalar();

                    if (townIdInObject == null)
                    {
                        using (SqlCommand sqlCommandToAddTown = new SqlCommand("INSERT INTO Towns (Name) VALUES (@townName)", sqlConnection))
                        {
                            sqlCommandToAddTown.Parameters.Add(new SqlParameter("@townName", minionTownName));
                            sqlCommandToAddTown.ExecuteNonQuery();
                            Console.WriteLine($"Town {minionTownName} was added to the database.");
                        }
                    }

                    townId = (int)sqlCommand.ExecuteScalar();
                }
                //differentiate
                using (SqlCommand sqlCommand = new SqlCommand("SELECT Id FROM Villains WHERE Name = @Name", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", vilianName));
                    object vilianIdInObject = sqlCommand.ExecuteScalar();

                    if (vilianIdInObject == null)
                    {
                        using (SqlCommand sqlCommandToAddVilian =
                            new SqlCommand("INSERT INTO Villains(Name, EvilnessFactorId)  VALUES(@villainName, 4)", sqlConnection))
                        {
                            sqlCommandToAddVilian.Parameters.Add(new SqlParameter("@villainName", vilianName));
                            sqlCommandToAddVilian.ExecuteNonQuery();
                            Console.WriteLine($"Villain {vilianName} was added to the database.");
                        }
                    }

                    evilId = (int)sqlCommand.ExecuteScalar();
                }
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Minions(Name, Age, TownId) VALUES(@nam, @age, @townId)"
                    , sqlConnection))
                {
                    sqlCommand.Parameters.AddRange(new SqlParameter[] {new SqlParameter("@nam",minionName) ,
                    new SqlParameter("@age",minionAge),new SqlParameter("@townId",townId)});
                    sqlCommand.ExecuteNonQuery();
                }
                using (SqlCommand sqlCommand = new SqlCommand("SELECT Id FROM Minions WHERE Name = @Name", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", minionName));
                    minionId = (int)sqlCommand.ExecuteScalar();
                }
                using (SqlCommand sqlCommand =
                    new SqlCommand("INSERT INTO MinionsVillains(VillainId,MinionId) VALUES(@villainId, @minionId)", sqlConnection))
                {
                    sqlCommand.Parameters.AddRange(new SqlParameter[] { new SqlParameter("villainId",evilId),
                    new SqlParameter("minionId",minionId)});
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {minionName} to be minion of {vilianName}.");
                }
            }
            

        }
    }
}
//SELECT Id FROM Villains WHERE Name = @Name
//SELECT Id FROM Minions WHERE Name = @Name
//INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(@villainId, @minionId)
//INSERT INTO Villains(Name, EvilnessFactorId)  VALUES(@villainName, 4)
//INSERT INTO Minions(Name, Age, TownId) VALUES(@nam, @age, @townId)
//INSERT INTO Towns(Name) VALUES(@townName)
//SELECT Id FROM Towns WHERE Name = @townName