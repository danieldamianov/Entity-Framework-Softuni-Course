namespace MiniORM.App
{
    using System;
    using System.Linq;
	using Data;
	using Data.Entities;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			var connectionString = @"Server=DESKTOP-B3I8JPR\SQLEXPRESS;Database=MiniORM;Integrated Security = true";

			var context = new SoftUniDbContext(connectionString);

            //context.Employees.Add(new Employee
            //{
            //	FirstName = "Gosho",
            //	LastName = "Inserted",
            //	DepartmentId = context.Departments.First().Id,
            //	IsEmployed = true,
            //});

            //var employee = context.Employees.Last();
            //employee.FirstName = "Modified";
            context.Departments.Add(new Department
            {
                Name = "Department1"
            });

            context.SaveChanges();
            context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Employee1FirstName",
                LastName = "Employee1LastName",
                DepartmentId = 1,
                IsEmployed = true
            });
            context.Employees.Add(new Employee
            {
                FirstName = "Employee2FirstName",
                LastName = "Employee2LastName",
                DepartmentId = 1,
                IsEmployed = true
            });
            context.Employees.Add(new Employee
            {
                FirstName = "Employee3FirstName",
                LastName = "Employee3LastName",
                DepartmentId = 1,
                IsEmployed = true
            });


            context.SaveChanges();
            context = new SoftUniDbContext(connectionString);


            Console.WriteLine(string.Join(" ", context.Departments.Single(d => d.Id == 1).Employees.Select(e => e.FirstName)));
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", context.Employees.Where(e => e.DepartmentId == 1).Select(e => e.FirstName)));

            //context.SaveChanges();
        }
    }
}