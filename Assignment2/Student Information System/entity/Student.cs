using System;
using System.Collections.Generic;

namespace assignment_2.entity
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<Payment> Payments { get; set; }

        public Student(int studentId, string firstName, string lastName, DateTime dob, string email, string phone)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            Email = email;
            PhoneNumber = phone;
            Enrollments = new List<Enrollment>();
            Payments = new List<Payment>();
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"ID: {StudentId}, Name: {FirstName} {LastName}, Email: {Email}");
        }

        public List<Course> GetEnrolledCourses()
        {
            List<Course> courseList = new List<Course>();
            foreach (var enrollment in Enrollments)
            {
                courseList.Add(enrollment.Course);
            }
            return courseList;
        }
    }
}
