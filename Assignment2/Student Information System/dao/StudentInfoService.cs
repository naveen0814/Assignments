using System;
using System.Collections.Generic;
using assignment_2.entity;
using assignment_2.dao;
using assignment_2.exception;
using System.Security.Cryptography;

namespace assignment_2.service
{
    public class StudentInfoService
    {
        private IStudentRepository studentRepo;
        private ICourseRepository courseRepo;
        private IEnrollmentRepository enrollmentRepo;
        private ITeacherRepository teacherRepo;
        private IPaymentRepository paymentRepo;

        public StudentInfoService()
        {
            studentRepo = new StudentRepositoryImpl();
            courseRepo = new CourseRepositoryImpl();
            enrollmentRepo = new EnrollmentRepositoryImpl();
            teacherRepo = new TeacherRepositoryImpl();
            paymentRepo = new PaymentRepositoryImpl();
        }

        public void AddStudent()
        {
            Console.Write("First Name: ");
            string fname = Console.ReadLine();
            Console.Write("Last Name: ");
            string lname = Console.ReadLine();
            Console.Write("DOB (yyyy-mm-dd): ");
            DateTime dob = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Student s = new Student(0, fname, lname, dob, email, phone);
            studentRepo.AddStudent(s);
            Console.WriteLine("Student added.");
        }

        public void ViewAllStudents()
        {
            List<Student> students = studentRepo.GetAllStudents();
            foreach (var s in students)
            {
                s.DisplayStudentInfo();
            }
        }

        public void AddCourse()
        {
            Console.Write("Course Name: ");
            string name = Console.ReadLine();
            Console.Write("Course ID: ");
            int cid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Teacher ID: ");
            int Tid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Credits: ");
            int credits = Convert.ToInt32(Console.ReadLine());

            Course c = new Course(cid, name, credits, Tid);
            courseRepo.AddCourse(c);
            Console.WriteLine("Course added.");
        }

        public void ViewAllCourses()
        {
            List<Course> courses = courseRepo.GetAllCourses();
            foreach (var c in courses)
            {
                c.DisplayCourseInfo();
            }
        }

        public void EnrollStudent()
        {
            Console.Write("Student ID: ");
            int sid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Course ID: ");
            int cid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            Student s = studentRepo.GetStudentById(sid);
            Course c = courseRepo.GetCourseById(cid);

            Enrollment e = new Enrollment(0, s, c, date);
            enrollmentRepo.AddEnrollment(e);
            Console.WriteLine("Enrollment created.");
        }

        public void RecordPayment()
        {
            Console.Write("Student ID: ");
            int sid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            Student s = studentRepo.GetStudentById(sid);
            Payment p = new Payment(0, s, amount, date);
            paymentRepo.AddPayment(p);
            Console.WriteLine("Payment recorded.");
        }

        public void AddTeacher()
        {
            Console.Write("First Name: ");
            string fname = Console.ReadLine();
            Console.Write("Last Name: ");
            string lname = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Teacher t = new Teacher(0, fname, lname, email);
            teacherRepo.AddTeacher(t);
            Console.WriteLine("Teacher added.");
        }

        public void ViewTeachers()
        {
            List<Teacher> teachers = teacherRepo.GetAllTeachers();
            foreach (var t in teachers)
            {
                t.DisplayTeacherInfo();
            }
        }
    }
}
