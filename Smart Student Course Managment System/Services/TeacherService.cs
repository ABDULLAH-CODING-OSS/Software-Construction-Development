using System;
using Microsoft.Data.Sqlite;
using Smart_Student_Course_Managment_System.Database;

namespace Smart_Student_Course_Managment_System.Services
{
    internal class TeacherService
    {
        DatabaseManager dbManager = new DatabaseManager();

        // ADD TEACHER
        public void addTeacher()
        {
            try
            {
                Console.WriteLine("===== ADD TEACHER =====");

                Console.Write("Enter Teacher ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Teacher Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Teacher Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter Teacher Subject: ");
                string subject = Console.ReadLine();

                Console.Write("Enter Teacher Department: ");
                string department = Console.ReadLine();

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    INSERT INTO Teachers
                    (TeacherId, Name, Age, Subject, Department)
                    VALUES
                    (@id, @name, @age, @subject, @department)";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@subject", subject);
                        cmd.Parameters.AddWithValue("@department", department);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("\nTeacher Added Successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // VIEW TEACHERS
        public void viewTeachers()
        {
            try
            {
                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM Teachers";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\n===== TEACHERS LIST =====\n");

                            bool found = false;

                            while (reader.Read())
                            {
                                found = true;

                                Console.WriteLine("----------------------------");
                                Console.WriteLine($"Teacher ID   : {reader["TeacherId"]}");
                                Console.WriteLine($"Name         : {reader["Name"]}");
                                Console.WriteLine($"Age          : {reader["Age"]}");
                                Console.WriteLine($"Subject      : {reader["Subject"]}");
                                Console.WriteLine($"Department   : {reader["Department"]}");
                            }

                            if (!found)
                            {
                                Console.WriteLine("No Teachers Found.");
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

        // DELETE TEACHER
        public void deleteTeacher()
        {
            try
            {
                Console.WriteLine("===== DELETE TEACHER =====");

                Console.Write("Enter Teacher ID to Delete: ");
                int id = int.Parse(Console.ReadLine());

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    DELETE FROM Teachers
                    WHERE TeacherId = @id";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\nTeacher Deleted Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nTeacher Not Found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // UPDATE TEACHER
        public void updateTeacher()
        {
            try
            {
                Console.WriteLine("===== UPDATE TEACHER =====");

                Console.Write("Enter Teacher ID to Update: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter New Teacher Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter New Teacher Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter New Teacher Subject: ");
                string subject = Console.ReadLine();

                Console.Write("Enter New Teacher Department: ");
                string department = Console.ReadLine();

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    UPDATE Teachers
                    SET Name = @name,
                        Age = @age,
                        Subject = @subject,
                        Department = @department
                    WHERE TeacherId = @id";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@subject", subject);
                        cmd.Parameters.AddWithValue("@department", department);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\nTeacher Updated Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nTeacher Not Found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // SEARCH TEACHER
        public void searchTeacherByName()
        {
            try
            {
                Console.WriteLine("===== SEARCH TEACHER =====");

                Console.Write("Enter Teacher Name to Search: ");
                string name = Console.ReadLine();

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT * FROM Teachers
                    WHERE Name LIKE @name";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", $"%{name}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\n===== SEARCH RESULTS =====\n");

                            bool found = false;

                            while (reader.Read())
                            {
                                found = true;

                                Console.WriteLine("----------------------------");
                                Console.WriteLine($"Teacher ID   : {reader["TeacherId"]}");
                                Console.WriteLine($"Name         : {reader["Name"]}");
                                Console.WriteLine($"Age          : {reader["Age"]}");
                                Console.WriteLine($"Subject      : {reader["Subject"]}");
                                Console.WriteLine($"Department   : {reader["Department"]}");
                            }

                            if (!found)
                            {
                                Console.WriteLine("No Matching Teachers Found.");
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
    }
}