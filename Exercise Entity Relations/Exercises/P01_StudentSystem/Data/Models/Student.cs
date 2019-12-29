using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.CourseEnrollments = new List<StudentCourse>();
            this.HomeworkSubmissions = new List<Homework>();
        }

        public Student( string name, string phoneNumber, DateTime registeredOn, DateTime? birthday) : this()
        {
            Name = name;
            PhoneNumber = phoneNumber;
            RegisteredOn = registeredOn;
            Birthday = birthday;
        }

        public int StudentId { get; set; }
        
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }

//    Student:
//o StudentId
//o Name(up to 100 characters, unicode)
//o PhoneNumber(exactly 10 characters, not unicode, not required)
//o RegisteredOn
//o Birthday(not required)
}
