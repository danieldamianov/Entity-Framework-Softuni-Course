using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;
using System;
using System.Linq;

namespace P01_StudentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StudentSystemContext dbContext = new StudentSystemContext())
            {
                var students = dbContext.Students.Include(s => s.CourseEnrollments).ToArray();

                Student student = new Student("Dani", "089", new DateTime(2019, 01, 01), null);
                student.CourseEnrollments.Add(new StudentCourse() { Course = new Course("course1","good", new DateTime(2019, 01, 01), new DateTime(2019, 01, 01),100) });
                student.CourseEnrollments.Add(new StudentCourse() { Course = new Course("course2","bad", new DateTime(2019, 01, 01), new DateTime(2019, 01, 01),100) });

                foreach (var courseEnrollments in student.CourseEnrollments)
                {
                    courseEnrollments.Course.Resources.Add(new Resource("res1","url1",Data.Models.Enums.ResourceType.Document));
                }

                student.HomeworkSubmissions.Add(new Homework("homework1", Data.Models.Enums.ContentType.Application, new DateTime(2019, 01, 01)) { CourseId = 1});
                student.HomeworkSubmissions.Add(new Homework("homework2", Data.Models.Enums.ContentType.Application, new DateTime(2019, 01, 01)) { CourseId = 2});
                student.HomeworkSubmissions.Add(new Homework("homework3", Data.Models.Enums.ContentType.Application, new DateTime(2019, 01, 01)) { CourseId = 1});
                student.HomeworkSubmissions.Add(new Homework("homework4", Data.Models.Enums.ContentType.Application, new DateTime(2019, 01, 01)) { CourseId = 2});

                dbContext.Students.Add(student);
                dbContext.SaveChanges();

                Student student2 = dbContext.Students.Find(1);
            }
        }
    }
}
