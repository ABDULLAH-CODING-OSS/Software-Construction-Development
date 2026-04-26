using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Activity_03_Software_Architectures.Models;
using Activity_03_Software_Architectures.Repositories;

namespace Activity_03_Software_Architectures.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void CreateTable()
        {
            using var con = new SqliteConnection(_connectionString);
            con.Open();

            string query = @"CREATE TABLE IF NOT EXISTS Student(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        Age INTEGER
                    );";

            var cmd = new SqliteCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public void Add(Student s)
        {
            using var con = new SqliteConnection(_connectionString);
            con.Open();

            var cmd = new SqliteCommand("INSERT INTO Student(Name, Age) VALUES(@name,@age)", con);
            cmd.Parameters.AddWithValue("@name", s.Name);
            cmd.Parameters.AddWithValue("@age", s.Age);

            cmd.ExecuteNonQuery();
        }

        public List<Student> GetAll()
        {
            using var con = new SqliteConnection(_connectionString);
            con.Open();

            var cmd = new SqliteCommand("SELECT * FROM Student", con);
            var reader = cmd.ExecuteReader();

            var students = new List<Student>();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Age = Convert.ToInt32(reader["Age"])
                });
            }

            return students;
        }

        public void Update(Student s)
        {
            using var con = new SqliteConnection(_connectionString);
            con.Open();

            var cmd = new SqliteCommand("UPDATE Student SET Name=@name, Age=@age WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("@name", s.Name);
            cmd.Parameters.AddWithValue("@age", s.Age);
            cmd.Parameters.AddWithValue("@id", s.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var con = new SqliteConnection(_connectionString);
            con.Open();

            var cmd = new SqliteCommand("DELETE FROM Student WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
