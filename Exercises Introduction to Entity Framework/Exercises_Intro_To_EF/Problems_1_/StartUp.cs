using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext softUniContext = new SoftUniContext())
            {
                Console.WriteLine(GetLatestProjects(softUniContext));
            }

        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townToRemove = context.Towns.Single(t => t.Name == "Seattle");

            var employeesInSeatle = context.Employees
                .Include(e => e.Address)
                .Where(e => e.Address.TownId == townToRemove.TownId);

            foreach (var employee in employeesInSeatle)
            {
                employee.AddressId = null;
            }

            context.SaveChanges();

            context.Addresses.RemoveRange(context.Addresses.Where(a => a.TownId == townToRemove.TownId));

            int addressesRemoved = context.SaveChanges();

            context.Towns.Remove(townToRemove);

            return $"{addressesRemoved} addresses in Seattle were deleted";
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            context.EmployeesProjects.RemoveRange(context.EmployeesProjects.Where(ep => ep.ProjectId == 2));

            var projectToDelete = context.Projects.Find(2);

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var project in context.Projects.Take(10))
            {
                stringBuilder.AppendLine(project.Name);
            }

            return stringBuilder.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => EF.Functions.Like(e.FirstName,"sa%"))
                .OrderBy( e => e.FirstName)
                .ThenBy(e => e.LastName);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return stringBuilder.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departmentNames = { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Include(e => e.Department)
                .Where(e => departmentNames.Contains(e.Department.Name));

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var employee in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return stringBuilder.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,p.Description,p.StartDate
                });

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var project in projects)
            {
                stringBuilder.AppendLine(project.Name);
                stringBuilder.AppendLine(project.Description);
                stringBuilder.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture));
            }

            return stringBuilder.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    Name = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new { e.FirstName, e.LastName, e.JobTitle })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                });

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var department in departments)
            {
                stringBuilder.AppendLine($"{department.Name} - {department.ManagerFirstName}  {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return stringBuilder.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.EmployeesProjects)
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName, e.LastName, e.JobTitle,Projects = e.EmployeesProjects.Select(ep => ep.Project)
                });

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{employees.First().FirstName} {employees.First().LastName} - {employees.First().JobTitle}");

            foreach (var project in employees.First().Projects.OrderBy(p => p.Name))
            {
                stringBuilder.AppendLine(project.Name);
            }

            return stringBuilder.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(a => a.Town)
                .Include(a => a.Employees)
                .Select(a => new
                {
                    a.AddressText,
                    a.Town.Name,
                    a.Employees.Count
                })
                .OrderByDescending(a => a.Count)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.AddressText)
                .Take(10);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var address in addresses)
            {
                stringBuilder.AppendLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            }

            return stringBuilder.ToString();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.EmployeesProjects)
                .Include(e => e.Manager)
                .Where(emp => emp.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .OrderBy(emp => emp.EmployeeId)
                .Select(emp => new
                {
                    emp.FirstName,
                    emp.LastName,
                    ManagerFirstName = emp.Manager.FirstName,
                    ManagerLastName = emp.Manager.LastName,
                    Projects = emp.EmployeesProjects.Select(ep => ep.Project)
                }).Take(10);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var emplpyee in employees)
            {
                stringBuilder.AppendLine($"{emplpyee.FirstName} {emplpyee.LastName} - Manager: {emplpyee.ManagerFirstName} {emplpyee.ManagerLastName}");
                var projects = emplpyee.Projects;

                foreach (var project in projects)
                {
                    string endDate = project.EndDate != null ?  $"{((DateTime)project.EndDate).ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture)}" : "not finished";
                    stringBuilder
                        .AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}"); 
                }
            }

            return stringBuilder.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            context.Employees.First(e => e.LastName == "Nakov")
                .Address = new Models.Address() { AddressText = "Vitoshka 15",TownId = 4 };

            context.SaveChanges();

            var employees = context.Employees.Include(e => e.Address)
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10);

            return string.Join(Environment.NewLine, employees);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Include(e => e.Department)
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,e.LastName,e.Department.Name,e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var emp in employees)
            {
                stringBuilder.AppendLine($"{emp.FirstName} {emp.LastName} from Research and Development - ${emp.Salary:f2}");
            }

            return stringBuilder.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new
            {
                e.FirstName,
                e.Salary
            }).Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName);


            StringBuilder stringBuilder = new StringBuilder();

            foreach (var emp in employees)
            {
                stringBuilder.AppendLine($"{emp.FirstName} - {emp.Salary:f2}");
            }

            return stringBuilder.ToString();

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,e.LastName,e.MiddleName,e.JobTitle,e.Salary,e.EmployeeId
                })
                .OrderBy(e => e.EmployeeId);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var emp in employees)
            {
                stringBuilder.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
            }

            return stringBuilder.ToString();
        }
    }
}//Guy Gilbert R Production Technician 12500.00
