using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Student_Course_Managment_System.Models
{
    internal class Enrollment
    {
        public int enrollmentId { get; set; }
        public int studentId { get; set; }
        public int courseId { get; set; }
        public Enrollment() { }
        public Enrollment(int enrollmentId, int studentId, int courseId)
        {
            this.enrollmentId = enrollmentId;
            this.studentId = studentId;
            this.courseId = courseId;
        }
    }
}
