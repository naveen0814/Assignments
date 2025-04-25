using System;
using assignment_2.service;
using assignment_2.exception;

namespace assignment_2.main
{
    public class MainModule
    {
        static void Main(string[] args)
        {
            StudentInfoService sis = new StudentInfoService();

            while (true)
            {
                Console.WriteLine(" - - - STUDENT INFORMATION SYSTEM - - - ");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. View All Courses");
                Console.WriteLine("5. Enroll Student");
                Console.WriteLine("6. Record Payment");
                Console.WriteLine("7. Add Teacher");
                Console.WriteLine("8. View Teachers");
                Console.WriteLine("9. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": sis.AddStudent(); break;
                        case "2": sis.ViewAllStudents(); break;
                        case "3": sis.AddCourse(); break;
                        case "4": sis.ViewAllCourses(); break;
                        case "5": sis.EnrollStudent(); break;
                        case "6": sis.RecordPayment(); break;
                        case "7": sis.AddTeacher(); break;
                        case "8": sis.ViewTeachers(); break;
                        case "9": Console.WriteLine("Goodbye!"); return;
                        default: Console.WriteLine("Invalid option. Try again."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] {ex.Message}");
                }

                Console.WriteLine();
            }
        }
    }
}
