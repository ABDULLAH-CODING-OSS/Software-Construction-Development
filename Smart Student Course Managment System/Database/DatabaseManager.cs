using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Student_Course_Managment_System.Database
{
    internal class DatabaseManager
    {
        private string connectionString = "Data Source=SCMSdb";
        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }
        public void createTables()
        {
            using (SqliteConnection conn = GetConnection())
            {
                conn.Open();
                string createStudentsTable = @"
                CREATE TABLE IF NOT EXISTS Students(
                    StudentId INTEGER PRIMARY KEY,
                    Name TEXT,
                    Age INTEGER,
                    Department TEXT
                )";
                string createTeachersTable = @"
                CREATE TABLE IF NOT EXISTS Teachers(
                    TeacherId INTEGER PRIMARY KEY,
                    Name TEXT,
                    Age INTEGER,
                    Subject TEXT,
                    Department TEXT
                )";
                string createCoursesTable = @"
                CREATE TABLE IF NOT EXISTS Courses(
                    CourseId INTEGER PRIMARY KEY,
                    Title TEXT,
                    CreditHours TEXT
                )";
                 
                string createEnrollmentsTable = @"
                CREATE TABLE IF NOT EXISTS Enrollments(
                    EnrollmentId INTEGER PRIMARY KEY,
                    StudentId INTEGER,
                    CourseId INTEGER
                )";
               string teacherCourseTable = @"
               CREATE TABLE IF NOT EXISTS TeacherCourses(
               AssignmentId INTEGER PRIMARY KEY AUTOINCREMENT,
               TeacherId INTEGER,
               CourseId INTEGER
               )";

                SqliteCommand cmd;
                cmd = new SqliteCommand(createStudentsTable, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqliteCommand(createTeachersTable, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqliteCommand(createCoursesTable, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqliteCommand(createEnrollmentsTable, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqliteCommand(teacherCourseTable, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}