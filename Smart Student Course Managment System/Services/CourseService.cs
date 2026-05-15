using System;
using Microsoft.Data.Sqlite;
using Smart_Student_Course_Managment_System.Database;

namespace Smart_Student_Course_Managment_System.Services
{
    internal class CourseService
    {
        DatabaseManager databaseManager = new DatabaseManager();

        // ADD COURSE
        public void addCourse()
        {
            try
            {
                Console.WriteLine("===== ADD COURSE =====");

                Console.Write("Enter Course ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Course Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Course Credit Hours: ");
                string creditHours = Console.ReadLine();

                using (var conn = databaseManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    INSERT INTO Courses
                    (CourseId, Title, CreditHours)
                    VALUES
                    (@id, @title, @creditHours)";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@creditHours", creditHours);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("\nCourse Added Successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // VIEW COURSES
        public void viewCourses()
        {
            try
            {
                using (var conn = databaseManager.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM Courses";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\n===== COURSES LIST =====\n");

                            bool found = false;

                            while (reader.Read())
                            {
                                found = true;

                                Console.WriteLine("----------------------------");
                                Console.WriteLine($"Course ID     : {reader["CourseId"]}");
                                Console.WriteLine($"Course Title  : {reader["Title"]}");
                                Console.WriteLine($"Credit Hours  : {reader["CreditHours"]}");
                            }

                            if (!found)
                            {
                                Console.WriteLine("No Courses Found.");
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

        // DELETE COURSE
        public void deleteCourse()
        {
            try
            {
                Console.WriteLine("===== DELETE COURSE =====");

                Console.Write("Enter Course ID to Delete: ");
                int id = int.Parse(Console.ReadLine());

                using (var conn = databaseManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    DELETE FROM Courses
                    WHERE CourseId = @id";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\nCourse Deleted Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nCourse Not Found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // UPDATE COURSE
        public void updateCourse()
        {
            try
            {
                Console.WriteLine("===== UPDATE COURSE =====");

                Console.Write("Enter Course ID to Update: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter New Course Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter New Credit Hours: ");
                string creditHours = Console.ReadLine();

                using (var conn = databaseManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    UPDATE Courses
                    SET Title = @title,
                        CreditHours = @creditHours
                    WHERE CourseId = @id";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@creditHours", creditHours);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\nCourse Updated Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nCourse Not Found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // SEARCH COURSE
        public void searchCourse()
        {
            try
            {
                Console.WriteLine("===== SEARCH COURSE =====");

                Console.Write("Enter Course Title to Search: ");
                string title = Console.ReadLine();

                using (var conn = databaseManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT * FROM Courses
                    WHERE Title LIKE @title";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", $"%{title}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\n===== SEARCH RESULTS =====\n");

                            bool found = false;

                            while (reader.Read())
                            {
                                found = true;

                                Console.WriteLine("----------------------------");
                                Console.WriteLine($"Course ID     : {reader["CourseId"]}");
                                Console.WriteLine($"Course Title  : {reader["Title"]}");
                                Console.WriteLine($"Credit Hours  : {reader["CreditHours"]}");
                            }

                            if (!found)
                            {
                                Console.WriteLine("No Matching Courses Found.");
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