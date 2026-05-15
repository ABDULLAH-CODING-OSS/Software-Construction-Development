using Microsoft.Data.Sqlite;
using Smart_Student_Course_Managment_System.Database;
using System;

namespace Smart_Student_Course_Managment_System.Services
{
    internal class StudentServices
    {
        DatabaseManager dbManager = new DatabaseManager();

        // ADD STUDENT
        public void addStudent()
        {
            try
            {
                Console.WriteLine("===== ADD STUDENT =====");

                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Student Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter Student Department: ");
                string department = Console.ReadLine();

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    INSERT INTO Students
                    (StudentId, Name, Age, Department)
                    VALUES
                    (@id, @name, @age, @department)";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@department", department);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("\nStudent Added Successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // VIEW STUDENTS
        public void viewStudents()
        {
            try
            {
                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM Students";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\n===== STUDENTS LIST =====\n");

                            bool found = false;

                            while (reader.Read())
                            {
                                found = true;

                                Console.WriteLine("----------------------------");
                                Console.WriteLine($"ID         : {reader["StudentId"]}");
                                Console.WriteLine($"Name       : {reader["Name"]}");
                                Console.WriteLine($"Age        : {reader["Age"]}");
                                Console.WriteLine($"Department : {reader["Department"]}");
                            }

                            if (!found)
                            {
                                Console.WriteLine("No Students Found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // DELETE STUDENT
        public void deleteStudent()
        {
            try
            {
                Console.WriteLine("===== DELETE STUDENT =====");

                Console.Write("Enter Student ID to Delete: ");
                int id = int.Parse(Console.ReadLine());

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = "DELETE FROM Students WHERE StudentId = @id";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\nStudent Deleted Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nStudent Not Found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // SEARCH STUDENT
        public void searchStudent()
        {
            try
            {
                Console.WriteLine("===== SEARCH STUDENT =====");

                Console.Write("Enter Student ID to Search: ");
                int id = int.Parse(Console.ReadLine());

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM Students WHERE StudentId = @id";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("\n===== STUDENT FOUND =====");

                                Console.WriteLine("----------------------------");
                                Console.WriteLine($"ID         : {reader["StudentId"]}");
                                Console.WriteLine($"Name       : {reader["Name"]}");
                                Console.WriteLine($"Age        : {reader["Age"]}");
                                Console.WriteLine($"Department : {reader["Department"]}");
                            }
                            else
                            {
                                Console.WriteLine("\nStudent Not Found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // UPDATE STUDENT
        public void updateStudent()
        {
            try
            {
                Console.WriteLine("===== UPDATE STUDENT =====");

                Console.Write("Enter Student ID to Update: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter New Student Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter New Student Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter New Student Department: ");
                string department = Console.ReadLine();

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    UPDATE Students
                    SET Name = @name,
                        Age = @age,
                        Department = @department
                    WHERE StudentId = @id";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@department", department);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\nStudent Updated Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nStudent Not Found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}