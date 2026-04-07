using System;

namespace L2Submission
{
    class Employee
    {
        private string name;
        private int id;
        private double salary;
        public Employee(string name, int id, double salary)
        {
            this.name = name;
            this.id = id;
            this.salary = salary;
            Console.WriteLine("Employee is Initialized with Parameterized Values !!!!!");
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Salary
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
        public void displayInfo()
        {
            Console.WriteLine("Name of Employee is : " + name + " ID is : " + id + "  Salary is : " + salary + " RS");
        }
        public void calculateBonus()
        {
            double bonus = salary * 0.10;
            Console.WriteLine("Bonus for Employee " + name + " is : " + bonus + " RS");
        }
        public void updateSalary(double newSalary)
        {
            Salary = newSalary; // Using the property to ensure validation
            Console.WriteLine("Salary updated for Employee " + name + " to : " + salary + " RS");

        }
        public static void searchEmployee(Employee[] employees, int targetId)
        {
            bool found = false;
            foreach (Employee employee in employees)
            {
                if (employee.id == targetId)
                {
                    Console.WriteLine("Employee Found....");
                    found = true;
                    employee.displayInfo();
                }
                
            }
            if (!found)
            {

                Console.WriteLine("Employee with ID " + targetId + " not found.");
            }

        }




        class Program
        {

            static void Main(string[] args)
            {
                Employee[] staff = new Employee[3];
                for (int i = 0; i < staff.Length; i++)
                {
                    staff[i] = new Employee("Employee " + (i + 1), i + 1, 50000 + (i * 5000));

                }
                Console.WriteLine("Displaying Employee Information:");
                for (int i = 0; i < staff.Length; i++)
                {
                    staff[i].displayInfo();

                }
                Console.WriteLine("\nCalculating Bonuses:");
                for (int i = 0; i < staff.Length; i++)
                {
                    staff[i].calculateBonus();
                    staff[i].updateSalary(50000 + (i * 7000)); // Updating salary with new values

                }
                Console.WriteLine("Searching for Employee with ID .... Enter ID");
                int choice = int.Parse(Console.ReadLine());
                searchEmployee(staff, choice);



                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

            }
        }
    }
}