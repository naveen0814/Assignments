using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using assignment_2.entity;
using assignment_2.util;

using assignment_2.exception;

namespace assignment_2.dao
{
    public class TeacherRepositoryImpl : ITeacherRepository
    {
        private string connStr;

        public TeacherRepositoryImpl()
        {
            connStr = DBPropertyUtil.GetConnectionString("SISDB");
        }

        public void AddTeacher(Teacher teacher)
        {
            if (string.IsNullOrWhiteSpace(teacher.FirstName) || string.IsNullOrWhiteSpace(teacher.LastName) || string.IsNullOrWhiteSpace(teacher.Email))
            {
                throw new InvalidTeacherDataException("Teacher data cannot be null or empty.");
            }

            using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Teacher (first_name, last_name, email) " +
                               "VALUES (@FirstName, @LastName, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", teacher.FirstName);
                cmd.Parameters.AddWithValue("@LastName", teacher.LastName);
                cmd.Parameters.AddWithValue("@Email", teacher.Email);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new InvalidTeacherDataException("Failed to add teacher. Please check the provided details.");
                }
            }
        }

        public void DeleteTeacher(int teacherId)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM Teacher WHERE teacher_id=@TeacherId";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@TeacherId", teacherId);

                int count = (int)checkCmd.ExecuteScalar();
                if (count == 0)
                {
                    throw new TeacherNotFoundException($"No teacher found with ID {teacherId}");
                }

                string query = "DELETE FROM Teacher WHERE teacher_id=@TeacherId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TeacherId", teacherId);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Teachers"; 
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    teachers.Add(new Teacher(
                        Convert.ToInt32(reader["teacher_id"]),
                        reader["first_name"].ToString(),
                        reader["last_name"].ToString(),
                        reader["email"].ToString()
                    ));
                }
            }

            if (teachers.Count == 0)
            {
                throw new TeacherNotFoundException("No teachers found in the system.");
            }

            return teachers;
        }
    }
}
