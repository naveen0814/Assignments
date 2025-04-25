using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using assignment_2.entity;
using assignment_2.util;
using assignment_2.exception;

namespace assignment_2.dao
{
    public class EnrollmentRepositoryImpl : IEnrollmentRepository
    {
        private string connStr;

        public EnrollmentRepositoryImpl()
        {
            connStr = DBPropertyUtil.GetConnectionString("SISDB");
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            if (enrollment.Student == null || enrollment.Course == null)
            {
                throw new InvalidEnrollmentDataException("Student or Course cannot be null.");
            }

            if (enrollment.EnrollmentDate > DateTime.Now)
            {
                throw new InvalidEnrollmentDataException("Enrollment date cannot be in the future.");
            }

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO Enrollments (student_id, course_id, enrollment_date) " +
                                   "VALUES (@StudentId, @CourseId, @Date)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentId", enrollment.Student.StudentId);
                    cmd.Parameters.AddWithValue("@CourseId", enrollment.Course.CourseId);
                    cmd.Parameters.AddWithValue("@Date", enrollment.EnrollmentDate);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidEnrollmentDataException("Database error while enrolling student: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new InvalidEnrollmentDataException("Unexpected error while enrolling student: " + ex.Message);
            }
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM Enrollments WHERE enrollment_id=@EnrollmentId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidEnrollmentDataException($"No enrollment found with ID {enrollmentId}.");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidEnrollmentDataException("Database error while deleting enrollment: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new InvalidEnrollmentDataException("Unexpected error while deleting enrollment: " + ex.Message);
            }
        }

        public List<Enrollment> GetAllEnrollments()
        {
            List<Enrollment> list = new List<Enrollment>();

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM Enrollments";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Enrollment enroll = new Enrollment(
                            Convert.ToInt32(reader["enrollment_id"]),
                            new Student(Convert.ToInt32(reader["student_id"]), "", "", DateTime.Now, "", ""),
                            new Course(
                                Convert.ToInt32(reader["course_id"]),
                                reader["course_name"]?.ToString() ?? "Unknown",
                                Convert.ToInt32(reader["credits"]), 
                                Convert.ToInt32(reader["teacher_id"]) 
                            ),
                            Convert.ToDateTime(reader["enrollment_date"])
                        );
                        list.Add(enroll);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw new InvalidEnrollmentDataException("Database error while loading enrollments: " + ex.Message);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidEnrollmentDataException("Data conversion error while loading enrollments: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new InvalidEnrollmentDataException("Unexpected error while loading enrollments: " + ex.Message);
            }

            return list;
        }
    }
}
