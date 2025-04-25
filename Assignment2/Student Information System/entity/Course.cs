using assignment_2.entity;
using System;
using System.Collections.Generic;

namespace assignment_2.entity
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; } 
        public int TeacherId { get; set; } 
        public List<Enrollment> Enrollments { get; set; }

        public Course(int courseId, string courseName, int credits, int teacherId)
        {
            CourseId = courseId;
            CourseName = courseName;
            Credits = credits;  
            TeacherId = teacherId;
            Enrollments = new List<Enrollment>();
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine($"ID: {CourseId}, Name: {CourseName}, Credits: {Credits}, Teacher ID: {TeacherId}");
        }
    }
}
