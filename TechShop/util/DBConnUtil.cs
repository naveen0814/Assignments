using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TechShop.util
{
    public static class DBConnUtil
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Server=NAVEEN;Database=TechShop;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(connectionString);
        }
    }
}