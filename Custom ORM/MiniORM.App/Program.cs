using MiniORM.App.Data;
using System;
using System.Linq;

namespace MiniORM.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-B3I8JPR\SQLEXPRESS;Database=MiniORM;Integrated Security = true";

            SoftuniDbContext softuniDbContext = new SoftuniDbContext(connectionString);

            softuniDbContext.Employees.Add(new Data.Entities.Employee()
            {
                FirstName = "Allesia",
                LastName = "Mabboni",
                DepartmentId = softuniDbContext.Departments.First().Id,
                IsEmployed = true
            });

            softuniDbContext.Projects.Add(new Data.Entities.Project()
            {
                Name = "Project1"
            });

            Console.WriteLine(string.Join(" ",softuniDbContext.Departments.Single(d => d.Id == 1).Employees.Select(e => e.FirstName)));

            softuniDbContext.SaveChanges();
        }
    }
}
