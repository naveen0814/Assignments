using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using assignment_2.entity;
using assignment_2.util;
using assignment_2.exception;

namespace assignment_2.dao
{
    public class CourseRepositoryImpl : ICourseRepository
    {
        private string connStr;

        public CourseRepositoryImpl()
        {
            connStr = DBPropertyUtil.GetConnectionString("SISDB");
        }

        public void AddCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.CourseName) || course.Credits <= 0 || course.TeacherId <= 0)
                throw new InvalidCourseDataException("Course name, credits, or teacher ID cannot be empty or invalid.");

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO Courses (course_name, credits, teacher_id) VALUES (@CourseName, @Credits, @TeacherId)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@Credits", course.Credits);
                    cmd.Parameters.AddWithValue("@TeacherId", course.TeacherId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidCourseDataException("Database error while adding course: " + ex.Message);
            }
        }

        public void UpdateCourse(Course course)
        {
            if (course.CourseId <= 0)
                throw new InvalidCourseDataException("Invalid course ID.");

            if (string.IsNullOrWhiteSpace(course.CourseName) || course.Credits <= 0 || course.TeacherId <= 0)
                throw new InvalidCourseDataException("Course name, credits, or teacher ID cannot be empty or invalid.");

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE Courses SET course_name=@CourseName, credits=@Credits, teacher_id=@TeacherId WHERE course_id=@CourseId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@Credits", course.Credits);
                    cmd.Parameters.AddWithValue("@TeacherId", course.TeacherId);
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new CourseNotFoundException($"No course found with ID: {course.CourseId}");
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidCourseDataException("Database error while updating course: " + ex.Message);
            }
        }

        public void DeleteCourse(int courseId)
        {
            if (courseId <= 0)
                throw new InvalidCourseDataException("Invalid course ID.");

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM Courses WHERE course_id=@CourseId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new CourseNotFoundException($"No course found with ID: {courseId}");
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidCourseDataException("Database error while deleting course: " + ex.Message);
            }
        }

        public Course GetCourseById(int courseId)
        {
            if (courseId <= 0)
                throw new InvalidCourseDataException("Invalid course ID.");

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM Courses WHERE course_id=@CourseId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Course(
                            Convert.ToInt32(reader["course_id"]),
                            reader["course_name"].ToString(),
                            Convert.ToInt32(reader["credits"]),
                            Convert.ToInt32(reader["teacher_id"])
                        );
                    }
                    else
                    {
                        throw new CourseNotFoundException($"No course found with ID: {courseId}");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidCourseDataException("Database error while retrieving course: " + ex.Message);
            }
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM Courses";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int courseId = Convert.ToInt32(reader["course_id"]);
                        string courseName = reader["course_name"].ToString();
                        int credits = Convert.ToInt32(reader["credits"]);
                        int teacherId = Convert.ToInt32(reader["teacher_id"]);

                        Course course = new Course(
                            courseId,
                            courseName,
                            credits,
                            teacherId
                        );

                        courses.Add(course);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while retrieving courses: " + ex.Message);
            }

            return courses;
        }
    }
}
