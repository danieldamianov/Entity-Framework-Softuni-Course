﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFRelations.Infrastructure.Data.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public PersonName Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
