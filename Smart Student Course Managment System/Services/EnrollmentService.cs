using System;
using Microsoft.Data.Sqlite;
using Smart_Student_Course_Managment_System.Database;

namespace Smart_Student_Course_Managment_System.Services
{
    internal class EnrollmentService
    {
        DatabaseManager dbManager = new DatabaseManager();

        // ENROLL STUDENT
        public void enrollStudent()
        {
            try
            {
                Console.WriteLine("===== ENROLL STUDENT =====");

                Console.Write("Enter Student ID: ");
                int studentId = int.Parse(Console.ReadLine());

                Console.Write("Enter Course ID: ");
                int courseId = int.Parse(Console.ReadLine());

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    INSERT INTO Enrollments
                    (StudentId, CourseId)
                    VALUES
                    (@studentId, @courseId)";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@courseId", courseId);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("\nStudent Enrolled Successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // VIEW ENROLLMENTS
        public void viewEnrollments()
        {
            try
            {
                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        e.EnrollmentId,
                        s.Name AS StudentName,
                        c.Title AS CourseTitle
                    FROM Enrollments e

                    JOIN Students s
                    ON e.StudentId = s.StudentId

                    JOIN Courses c
                    ON e.CourseId = c.CourseId";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\n===== ENROLLMENTS LIST =====\n");

                            bool found = false;

                            while (reader.Read())
                            {
                                found = true;

                                Console.WriteLine("----------------------------");
                                Console.WriteLine($"Enrollment ID : {reader["EnrollmentId"]}");
                                Console.WriteLine($"Student Name  : {reader["StudentName"]}");
                                Console.WriteLine($"Course Title  : {reader["CourseTitle"]}");
                            }

                            if (!found)
                            {
                                Console.WriteLine("No Enrollments Found.");
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

        // DELETE ENROLLMENT
        public void deleteEnrollment()
        {
            try
            {
                Console.WriteLine("===== DELETE ENROLLMENT =====");

                Console.Write("Enter Enrollment ID to Delete: ");
                int enrollmentId = int.Parse(Console.ReadLine());

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    DELETE FROM Enrollments
                    WHERE EnrollmentId = @enrollmentId";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@enrollmentId", enrollmentId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\nEnrollment Deleted Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nEnrollment Not Found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // VIEW STUDENT COURSES
        public void viewStudentCourses()
        {
            try
            {
                Console.WriteLine("===== VIEW STUDENT COURSES =====");

                Console.Write("Enter Student ID: ");
                int studentId = int.Parse(Console.ReadLine());

                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        c.Title AS CourseTitle
                    FROM Enrollments e

                    JOIN Courses c
                    ON e.CourseId = c.CourseId

                    WHERE e.StudentId = @studentId";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\n===== STUDENT COURSES =====\n");

                            bool found = false;

                            while (reader.Read())
                            {
                                found = true;

                                Console.WriteLine("----------------------------");
                                Console.WriteLine($"Course Title : {reader["CourseTitle"]}");
                            }

                            if (!found)
                            {
                                Console.WriteLine("No Courses Found For This Student.");
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