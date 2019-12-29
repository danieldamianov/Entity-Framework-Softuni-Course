using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.StudentsEnrolled = new List<StudentCourse>();
            this.Resources = new List<Resource>();
            this.HomeworkSubmissions = new List<Homework>();
        }

        public Course(string name, string description, DateTime startDate, DateTime endDate, decimal price) : this()
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
        }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<StudentCourse> StudentsEnrolled { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
//}
//Course:
//o CourseId
//o Name(up to 80 characters, unicode)
//o Description(unicode, not required)
//o StartDate
//o EndDate
//o Price