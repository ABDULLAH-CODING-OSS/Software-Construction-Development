using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Student_Course_Managment_System.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { }
        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}");
        }
    }
}
