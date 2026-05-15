using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Smart_Student_Course_Managment_System.Models
{
    internal class Teacher: Person

    {
        public string subject { get; set; }
        public String Department { get; set; }
        public Teacher() { }
        public Teacher(int id, string name, int age, string subject, string department) : base(id, name, age)
        {
            this.subject = subject;
            Department = department;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Subject: {subject}, Department: {Department}");
        }
    }
}
