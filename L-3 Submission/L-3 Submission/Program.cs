using System;

// Task 1
class Math
{
    public int Multiply(int a, int b)
    {
        return a * b;
    }


    public int Multiply(int a, int b, int c)
    {
        return a * b * c;
    }


}

// Task 2
class Printer
{
    public void Print(string name)
    {
        Console.WriteLine("Name: " + name);
    }


    public void Print(int age)
    {
        Console.WriteLine("Age: " + age);
    }


}

// Task 3
class Area
{
    public int calculateArea(int side)
    {
        return side * side;
    }


public int calculateArea(int length, int width)
    {
        return length * width;
    }


}

// Task 4
class Person
{
    public void ShowName()
    {
        Console.WriteLine("Name: Ali");
    }
}

class Student : Person
{
    public void ShowGrade()
    {
        Console.WriteLine("Grade: A");
    }
}

// Task 5
class Vehicle
{
    public void Start()
    {
        Console.WriteLine("Vehicle Started");
    }
}

class Car : Vehicle
{
    public void Drive()
    {
        Console.WriteLine("Car Driving");
    }
}

// Task 6
interface IPrint
{
    void Print();
}

interface IScan
{
    void Scan();
}

class Machine : IPrint, IScan
{
    public void Print()
    {
        Console.WriteLine("Printing...");
    }


public void Scan()
    {
        Console.WriteLine("Scanning...");
    }


}

// Task 7
class PersonBase
{
    public void ShowPerson()
    {
        Console.WriteLine("I am a Person");
    }
}

class Employee : PersonBase
{
    public void ShowEmployee()
    {
        Console.WriteLine("I am an Employee");
    }
}

class Manager : Employee
{
    public void ShowManager()
    {
        Console.WriteLine("I am a Manager");
    }
}

// Task 8
class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal Sound");
    }
}

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Dog Barks");
    }
}

// Task 9
class EmployeeBase
{
    public virtual void Work()
    {
        Console.WriteLine("Employee Working");
    }
}

class Manager2 : EmployeeBase
{
    public override void Work()
    {
        Console.WriteLine("Manager Managing Work");
    }
}

// Task 10
class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing Shape");
    }
}

class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Rectangle");
    }
}

class Program
{
    static void Main()
    {
        Math m = new Math();
        Console.WriteLine(m.Multiply(2, 3));
        Console.WriteLine(m.Multiply(2, 3, 4));


    Printer p = new Printer();
        p.Print("Ali");
        p.Print(20);

        Area a = new Area();
        Console.WriteLine(a.calculateArea(5));
        Console.WriteLine(a.calculateArea(5, 10));

        Student s = new Student();
        s.ShowName();
        s.ShowGrade();

        Car c = new Car();
        c.Start();
        c.Drive();

        Machine mc = new Machine();
        mc.Print();
        mc.Scan();

        Manager mng = new Manager();
        mng.ShowPerson();
        mng.ShowEmployee();
        mng.ShowManager();

        Animal an = new Dog();
        an.Sound();

        EmployeeBase emp = new Manager2();
        emp.Work();

        Shape sh = new Rectangle();
        sh.Draw();
    }


}
