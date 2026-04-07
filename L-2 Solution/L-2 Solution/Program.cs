using System;

namespace L2Submission
{
    // Task : 1 Crete a Simple Class with a Method to Display Information
    class Student
    {
        public string Name { get; set; }
        public Student() {
            Console.WriteLine("Student  object created."); // Task : 3 Create a Default Constructor with a message
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Student Name: {Name}");
        }
    }
    // Task : 2 Create a Class with a Private Variable and a setter and a display method
    class Teacher
    {
        public string Name { get; set; }
        private double salary;
        public Teacher(string name, double sal) {
            this.Name = name; // Task 5:  Using This Keyword
            this.salary = sal;

            Console.WriteLine("Teacher object created and name of the Teacher " + name + ": Salary is " + sal); // Task : 4 Create a Parameterized Constructor with a message
        }
        public double salaryAmount
        {
            get { return salary; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Salary cannot be negative. Setting salary to 0.");
                    salary = 0;
                }
                else
                {
                    salary = value;
                }
            }
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Teacher Name: {Name}, Salary: {salaryAmount}");
        }
    }

    class Employee
    {
        private double salary;
        private string name;
        public Employee(string name , double salary)
        {
            this.name = name;
            this.salary = salary;
            Console.WriteLine("Employee object created and name of the Employee " + name + ": Salary is " + salary);
        }
        public string Name
        {
            set { name = "value"; }
            get { return name; }

        }
        public void DisplayInfo()
        {
            Console.WriteLine("Task 6 Done & Dusted");
            Console.WriteLine($"Employee Name: {name}, Salary: {salary}");
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
           
            Student obj = new Student(); // Task : 1
           
            
            obj.Name = "Abdullah Javed";
            obj.DisplayInfo();
           


            Teacher obj1 = new Teacher("Ahmad Abdali", 500000); // Tasak 2+3+4+5
            obj1.DisplayInfo();
            obj1.Name = "Ahmad Abduhu";
           
            obj1.salaryAmount = 5000;
            obj1.DisplayInfo();
            

            Employee emp = new Employee("Ali", 5000); // Task 6
            emp.DisplayInfo();
            emp.Name= "Ali Khan";
            emp.DisplayInfo();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}