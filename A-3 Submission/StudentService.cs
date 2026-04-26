using System;
using System.Collections.Generic;
using System.Text;
using Activity_03_Software_Architectures.Models;
using Activity_03_Software_Architectures.Repositories;

namespace Activity_03_Software_Architectures.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public void AddStudent(Student student)
        {
            // Business Rule Example
            if (student.Age < 0)
                throw new Exception("Age cannot be negative");

            _repository.Add(student);
        }

        public List<Student> GetStudents()
        {
            return _repository.GetAll();
        }

        public void UpdateStudent(Student student)
        {
            _repository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            _repository.Delete(id);
        }
    }
}
