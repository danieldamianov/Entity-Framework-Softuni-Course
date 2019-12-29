using P01_StudentSystem.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public Resource(string name, string url, ResourceType resourceType)
        {
            Name = name;
            Url = url;
            ResourceType = resourceType;
        }

        public int ResourceId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

//Resource:
//o ResourceId
//o Name(up to 50 characters, unicode)
//o Url(not unicode)
//o ResourceType(enum – can be Video, Presentation, Document or Other)
//o CourseId
