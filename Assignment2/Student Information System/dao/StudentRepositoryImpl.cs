using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using assignment_2.entity;
using assignment_2.util;
using assignment_2.exception;

namespace assignment_2.dao
{
    public class StudentRepositoryImpl : IStudentRepository
    {
        private string connStr;

        public StudentRepositoryImpl()
        {
            connStr = DBPropertyUtil.GetConnectionString("SISDB");
        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FirstName) || string.IsNullOrWhiteSpace(student.LastName))
                throw new StudentValidationException("Student's first and last names cannot be empty.");

            if (student.DateOfBirth >= DateTime.Now)
                throw new StudentValidationException("Date of birth cannot be in the future.");

            if (string.IsNullOrWhiteSpace(student.Email) || !student.Email.Contains("@"))
                throw new StudentValidationException("Invalid email format.");

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO Students (first_name, last_name, date_of_birth, email, phone_number) " +
                                   "VALUES (@FirstName, @LastName, @DOB, @Email, @Phone)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@DOB", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Phone", student.PhoneNumber);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new StudentValidationException("Database error while adding student: " + ex.Message);
            }
        }

        public void UpdateStudent(Student student)
        {
            if (student.StudentId <= 0)
                throw new StudentValidationException("Invalid student ID.");

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE Students SET first_name=@FirstName, last_name=@LastName, date_of_birth=@DOB, " +
                                   "email=@Email, phone_number=@Phone WHERE student_id=@StudentId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@DOB", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Phone", student.PhoneNumber);
                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new StudentNotFoundException($"No student found with ID {student.StudentId}");
                }
            }
            catch (SqlException ex)
            {
                throw new StudentValidationException("Database error while updating student: " + ex.Message);
            }
        }

        public void DeleteStudent(int studentId)
        {
            if (studentId <= 0)
                throw new StudentValidationException("Invalid student ID.");

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM Students WHERE student_id=@StudentId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new StudentNotFoundException($"No student found with ID {studentId}");
                }
            }
            catch (SqlException ex)
            {
                throw new StudentValidationException("Database error while deleting student: " + ex.Message);
            }
        }

        public Student GetStudentById(int studentId)
        {
            if (studentId <= 0)
                throw new StudentValidationException("Invalid student ID.");

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM Students WHERE student_id=@StudentId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Student(
                            Convert.ToInt32(reader["student_id"]),
                            reader["first_name"].ToString(),
                            reader["last_name"].ToString(),
                            Convert.ToDateTime(reader["date_of_birth"]),
                            reader["email"].ToString(),
                            reader["phone_number"].ToString()
                        );
                    }
                    else
                    {
                        throw new StudentNotFoundException($"No student found with ID {studentId}");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new StudentValidationException("Database error while retrieving student: " + ex.Message);
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM Students";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        students.Add(new Student(
                            Convert.ToInt32(reader["student_id"]),
                            reader["first_name"].ToString(),
                            reader["last_name"].ToString(),
                            Convert.ToDateTime(reader["date_of_birth"]),
                            reader["email"].ToString(),
                            reader["phone_number"].ToString()
                        ));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new StudentValidationException("Database error while retrieving students: " + ex.Message);
            }

            return students;
        }
    }
}
