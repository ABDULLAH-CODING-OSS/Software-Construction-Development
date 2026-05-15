using Smart_Student_Course_Managment_System.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Student_Course_Managment_System.Menu
{
    internal class MainMenu
    {
        
        public void showMenu()
        {
            StudentServices studentServices = new StudentServices();
            TeacherService teacherService = new TeacherService();
            CourseService courseService = new CourseService();
            EnrollmentService enrollmentService = new EnrollmentService();
            TeacherCourseService teacherCourseService = new TeacherCourseService();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("========================================================");
                Console.WriteLine("     SMART STUDENT COURSE MANAGEMENT SYSTEM");
                Console.WriteLine("========================================================");

                Console.WriteLine("\n---------------- STUDENT MANAGEMENT ----------------");
                Console.WriteLine("  1. Add Student");
                Console.WriteLine("  2. View Students");
                Console.WriteLine("  3. Update Student");
                Console.WriteLine("  4. Delete Student");
                Console.WriteLine("  5. Search Student");

                Console.WriteLine("\n---------------- TEACHER MANAGEMENT ----------------");
                Console.WriteLine("  6. Add Teacher");
                Console.WriteLine("  7. View Teachers");
                Console.WriteLine("  8. Update Teacher");
                Console.WriteLine("  9. Delete Teacher");
                Console.WriteLine(" 10. Search Teacher");

                Console.WriteLine("\n----------------- COURSE MANAGEMENT ----------------");
                Console.WriteLine(" 11. Add Course");
                Console.WriteLine(" 12. View Courses");
                Console.WriteLine(" 13. Update Course");
                Console.WriteLine(" 14. Delete Course");
                Console.WriteLine(" 15. Search Course");

                Console.WriteLine("\n---------------- ENROLLMENT MANAGEMENT -------------");
                Console.WriteLine(" 16. Enroll Student in Course");
                Console.WriteLine(" 17. View Enrollments");
                Console.WriteLine(" 18. Delete Enrollment");
                Console.WriteLine(" 19. View Student Courses");

                Console.WriteLine("\n---------------- TEACHER COURSE MANAGEMENT -------------");
                Console.WriteLine(" 20. Assign Teacher to Course");
                Console.WriteLine(" 21. View Teacher Course Assignments");
                Console.WriteLine(" 22. Remove Teacher Course Assignment");
                Console.WriteLine(" 23. View Courses by Teacher");
                Console.WriteLine(" 24. View Teachers by Course");

                Console.WriteLine("\n========================================================");
                Console.WriteLine(" 25. Exit");
                Console.WriteLine("========================================================");

                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        studentServices.addStudent();
                        break;

                    case "2":
                        studentServices.viewStudents();
                        break;

                    case "3":
                        studentServices.updateStudent();
                        break;

                    case "4":
                        studentServices.deleteStudent();
                        break;

                    case "5":
                        studentServices.searchStudent();
                        break;

                    case "6":
                        teacherService.addTeacher();
                        break;

                    case "7":
                        teacherService.viewTeachers();
                        break;

                    case "8":
                        teacherService.updateTeacher();
                        break;

                    case "9":
                        teacherService.deleteTeacher();
                        break;

                    case "10":
                        teacherService.searchTeacherByName();
                        break;

                    case "11":
                        courseService.addCourse();
                        break;

                    case "12":
                        courseService.viewCourses();
                        break;

                    case "13":
                        courseService.updateCourse();
                        break;

                    case "14":
                        courseService.deleteCourse();
                        break;

                    case "15":
                        courseService.searchCourse();
                        break;

                    case "16":
                        enrollmentService.enrollStudent();
                        break;

                    case "17":
                        enrollmentService.viewEnrollments();
                        break;

                    case "18":
                        enrollmentService.deleteEnrollment();
                        break;

                    case "19":
                        enrollmentService.viewStudentCourses();
                        break;
                    case "20":
                        teacherCourseService.assignTeacherToCourse();

                        break;
                    case "21":
                        teacherCourseService.viewTeacherCourseAssignments();
                        break;
                    case "22":
                        teacherCourseService.removeTeacherCourseAssignment();
                        break;
                    case "23":
                        teacherCourseService.viewCoursesByTeacher();
                        break;
                    case "24":
                        teacherCourseService.viewTeachersByCourse();
                        break;
                    case "25":
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}