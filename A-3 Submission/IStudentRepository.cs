using Activity_03_Software_Architectures.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Activity_03_Software_Architectures.Repositories
{
    public interface IStudentRepository
    {
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
        void CreateTable();
        List<Student> GetAll();
    }
}
