using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using assignment_2.entity;
using assignment_2.exception;
using assignment_2.util;

namespace assignment_2.dao
{
    public class PaymentRepositoryImpl : IPaymentRepository
    {
        private string connStr;

        public PaymentRepositoryImpl()
        {
            connStr = DBPropertyUtil.GetConnectionString("SISDB");
        }

        public void AddPayment(Payment payment)
        {
            if (payment.Student == null)
            {
                throw new StudentNotFoundException("Cannot add payment: student is null.");
            }

            if (payment.Amount <= 0)
            {
                throw new PaymentValidationException("Amount must be greater than zero.");
            }

            if (payment.PaymentDate > DateTime.Now)
            {
                throw new PaymentValidationException("Payment date cannot be in the future.");
            }

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO Payments (student_id, amount, payment_date) VALUES (@StudentId, @Amount, @Date)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentId", payment.Student.StudentId);
                    cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                    cmd.Parameters.AddWithValue("@Date", payment.PaymentDate);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new PaymentValidationException("Database error while adding payment: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PaymentValidationException("Unexpected error while adding payment: " + ex.Message);
            }
        }

        public List<Payment> GetPaymentsByStudentId(int studentId)
        {
            List<Payment> payments = new List<Payment>();

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM Payments WHERE student_id=@StudentId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Payment payment = new Payment(
                            Convert.ToInt32(reader["payment_id"]),
                            new Student(studentId, "", "", DateTime.Now, "", ""),
                            Convert.ToDecimal(reader["amount"]),
                            Convert.ToDateTime(reader["payment_date"])
                        );
                        payments.Add(payment);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new PaymentValidationException("Database error while retrieving payments: " + ex.Message);
            }
            catch (InvalidCastException ex)
            {
                throw new PaymentValidationException("Data conversion error while retrieving payments: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new PaymentValidationException("Unexpected error while retrieving payments: " + ex.Message);
            }

            return payments;
        }
    }
}
