using Activity_03_Software_Architectures.Data;
using Activity_03_Software_Architectures.Models;
using Activity_03_Software_Architectures.Services;
using SQLitePCL;

namespace Activity_03_Software_Architectures;

class Program
{
    static void Main()
    {
        SQLitePCL.Batteries.Init();
        string connectionString = "Data Source=student.db";


        // Create repository
        var repository = new StudentRepository(connectionString);
        repository.CreateTable();

        // Inject into service
        var service = new StudentService(repository);

        // Add students
        service.AddStudent(new Student { Name = "Ali", Age = 22 });
        service.AddStudent(new Student { Name = "Ahmad", Age = 23 });
        service.AddStudent(new Student { Name = "Raza", Age = 24 });
        service.AddStudent(new Student { Name = "Abdullah Javed", Age = 17 });


        // Display students
        Console.WriteLine("All Students:");
        var students = service.GetStudents();
        foreach (var s in students)
        {
            Console.WriteLine($"Id={s.Id}, Name={s.Name}, Age={s.Age}");
        }

        // Update
        service.UpdateStudent(new Student { Id = 2, Name = "Junaid", Age = 30 });

        Console.WriteLine("\nAfter Update:");
        service.GetStudents().ForEach(s =>
            Console.WriteLine($"Id={s.Id}, Name={s.Name}, Age={s.Age}")
        );

        // Delete
        service.DeleteStudent(3);

        Console.WriteLine("\nAfter Delete:");
        service.GetStudents().ForEach(s =>
            Console.WriteLine($"Id={s.Id}, Name={s.Name}, Age={s.Age}")
        );
    }
}