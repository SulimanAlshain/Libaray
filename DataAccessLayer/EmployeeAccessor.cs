using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterface;
using System.Data;
using DataObjectLayer;

namespace DataAccessLayer
{
    public class EmployeeAccessor : EmployeeAccessorInterface
    {
        public List<Employee> selectEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_selectAllEmployees", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) { 
                        Employee employee = new Employee();
                        employee.EmployeeID = reader.GetInt32(0);
                        employee.GivenName = reader.GetString(1);
                        employee.FamilyName = reader.GetString (2);
                        employee.Phone = reader.GetString(3);
                        employee.Email = reader.GetString(4);
                        employee.password = reader.GetString(5);
                        employee.Active = reader.GetBoolean(6);
                        employee.Role = reader.GetString(7);
                        employees.Add(employee);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return employees;
        }

        public string selectEmployeeRole(int employeeID)
        {
            string role = string.Empty;
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_select_role_by_employeeId", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                        role = reader.GetString(0);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return role;
        }

        public int verifyUser(string userName, string password)
        {
            int result = 0;
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_verify_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", userName);
            cmd.Parameters.AddWithValue("@PasswordHash", password);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows ) {
                    while (reader.Read())
                    {
                        result = reader.GetInt32(0);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }finally { conn.Close(); }
            return result;
        }
    }
}
