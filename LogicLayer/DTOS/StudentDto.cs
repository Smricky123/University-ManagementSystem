using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.DTOS
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public int Age { get; set; }
        public string Dept { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
    }
}