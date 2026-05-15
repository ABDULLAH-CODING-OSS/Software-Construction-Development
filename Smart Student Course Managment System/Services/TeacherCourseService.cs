using Microsoft.Data.Sqlite;
using Smart_Student_Course_Managment_System.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Student_Course_Managment_System.Services
{
    internal class TeacherCourseService
    {
        DatabaseManager dbManager = new DatabaseManager();

        public void assignTeacherToCourse()
        {
            Console.Write("Enter Teacher ID: ");
            int teacherId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());

            using (var conn = dbManager.GetConnection())
            {
                conn.Open();

                string query = @"
                INSERT INTO TeacherCourses
                (TeacherId, CourseId)
                VALUES
                (@teacherId, @courseId)";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@teacherId", teacherId);
                    cmd.Parameters.AddWithValue("@courseId", courseId);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("\nTeacher Assigned Successfully!");
                }
            }
        }
        public void viewTeacherCourseAssignments()
        {
            using (var conn = dbManager.GetConnection())
            {
                conn.Open();

                string query = @"
        SELECT
            tc.AssignmentId,
            t.Name AS TeacherName,
            c.Title AS CourseTitle

        FROM TeacherCourses tc

        JOIN Teachers t
        ON tc.TeacherId = t.TeacherId

        JOIN Courses c
        ON tc.CourseId = c.CourseId";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\n===== TEACHER COURSE ASSIGNMENTS =====\n");

                        while (reader.Read())
                        {
                            Console.WriteLine($"Assignment ID : {reader["AssignmentId"]}");
                            Console.WriteLine($"Teacher Name  : {reader["TeacherName"]}");
                            Console.WriteLine($"Course Title  : {reader["CourseTitle"]}");

                            Console.WriteLine("----------------------------------");
                        }
                    }
                }
            }
        }
        public void removeTeacherCourseAssignment()
        {
            Console.Write("Enter Assignment ID to Remove: ");
            int assignmentId = int.Parse(Console.ReadLine());
            using (var conn = dbManager.GetConnection())
            {
                conn.Open();
                string query = @"
                DELETE FROM TeacherCourses
                WHERE AssignmentId = @assignmentId";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@assignmentId", assignmentId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("\nAssignment Removed Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("\nAssignment Not Found.");
                    }
                }
            }
        }
        public void viewCoursesByTeacher()
        {
            Console.Write("Enter Teacher ID: ");
            int teacherId = int.Parse(Console.ReadLine());
            using (var conn = dbManager.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT
                    c.Title AS CourseTitle
                FROM TeacherCourses tc
                JOIN Courses c
                ON tc.CourseId = c.CourseId
                WHERE tc.TeacherId = @teacherId";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@teacherId", teacherId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\n===== COURSES TAUGHT BY TEACHER =====\n");
                        bool found = false;
                        while (reader.Read())
                        {
                            found = true;
                            Console.WriteLine($"Course Title : {reader["CourseTitle"]}");
                            Console.WriteLine("----------------------------------");
                        }
                        if (!found)
                        {
                            Console.WriteLine("No Courses Found for this Teacher.");
                        }
                    }
                }
            }
        }
        public void viewTeachersByCourse()
        {
            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            using (var conn = dbManager.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT
                    t.Name AS TeacherName
                FROM TeacherCourses tc
                JOIN Teachers t
                ON tc.TeacherId = t.TeacherId
                WHERE tc.CourseId = @courseId";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\n===== TEACHERS ASSIGNED TO COURSE =====\n");
                        bool found = false;
                        while (reader.Read())
                        {
                            found = true;
                            Console.WriteLine($"Teacher Name : {reader["TeacherName"]}");
                            Console.WriteLine("----------------------------------");
                        }
                        if (!found)
                        {
                            Console.WriteLine("No Teachers Found for this Course.");
                        }
                    }
                }
            }

        }
    }
}