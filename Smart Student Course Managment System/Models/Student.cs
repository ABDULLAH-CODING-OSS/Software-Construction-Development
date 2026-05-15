using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Student_Course_Managment_System.Models
{
    internal class Student: Person
    {
        public string Department { get; set; }
        public Student() { }
        public Student(int id, string name, int age, string department) : base(id, name, age)
        {
            Department = department;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Department: {Department}");
        }
    }
}
