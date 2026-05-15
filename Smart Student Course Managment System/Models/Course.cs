using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Student_Course_Managment_System.Models
{
    internal class Course
    {
        public int CId { get; set; }
        public string title { get; set; }
        public string creditHours { get; set; }
        public Course() { }
        public Course(int cId, string title, string creditHours)
        {
            CId = cId;
            this.title = title;
            this.creditHours = creditHours;
        }


    }
}
