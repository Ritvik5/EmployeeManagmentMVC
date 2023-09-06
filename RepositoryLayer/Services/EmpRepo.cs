using CommonLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmpRepo : IEmpRepo
    {
        private readonly IConfiguration configuration;
        private readonly string ConnectionString;

        public EmpRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = configuration.GetConnectionString("MyDatabaseConnection");
        }
        //To Add Employee
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                int flag = 0;
                using(SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employeeModel.Name);
                    cmd.Parameters.AddWithValue("@ProfileImage", employeeModel.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);

                    con.Open();
                    flag = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return flag > 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //To view All Employee
        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            try
            {
                List<EmployeeModel> employees = new List<EmployeeModel>();
                using(SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        EmployeeModel employeeModel = new EmployeeModel();
                        employeeModel.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employeeModel.Name = Convert.ToString(reader["Name"]);
                        employeeModel.ProfileImage = Convert.ToString(reader["ProfileImage"]);
                        employeeModel.Gender = Convert.ToChar(reader["Gender"]);
                        employeeModel.Department = Convert.ToString(reader["Department"]);
                        employeeModel.Salary = Convert.ToDecimal(reader["Salary"]);
                        employeeModel.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        employeeModel.Notes = Convert.ToString(reader["Notes"]);

                        employees.Add(employeeModel);
                    }
                    con.Close();
                }
                return employees;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Get Employee by EmployeeId
        public EmployeeModel GetById(int empId)
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetById", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", empId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employee.Name = Convert.ToString(reader["Name"]);
                        employee.ProfileImage = Convert.ToString(reader["ProfileImage"]);
                        employee.Gender = Convert.ToChar(reader["Gender"]);
                        employee.Department = Convert.ToString(reader["Department"]);
                        employee.Salary = Convert.ToDecimal(reader["Salary"]);
                        employee.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        employee.Notes = Convert.ToString(reader["Notes"]);
                    }
                    con.Close();
                }
                return employee;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Update the employee Details
        public bool UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                int flag = 0;
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
                    cmd.Parameters.AddWithValue("@Name", employeeModel.Name);
                    cmd.Parameters.AddWithValue("@ProfileImage", employeeModel.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);

                    con.Open();
                    flag = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return flag > 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        // To Delete the employee by id
        public bool DeleteEmployee(int empId)
        {
            try
            {
                int flag = 0;
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", empId);

                    con.Open();
                    flag = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return flag > 0 ? true : false;

            }
            catch (Exception)
            {

                throw;
            }
        }
        //To Login the employee by id and name
        public EmployeeModel LogInEmployee(EmployeeLogin employeeLogin)
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spLoginEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", employeeLogin.EmployeeId);
                    cmd.Parameters.AddWithValue("@EmpName", employeeLogin.Name);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employee.Name = Convert.ToString(reader["Name"]);
                        employee.ProfileImage = Convert.ToString(reader["ProfileImage"]);
                        employee.Gender = Convert.ToChar(reader["Gender"]);
                        employee.Department = Convert.ToString(reader["Department"]);
                        employee.Salary = Convert.ToDecimal(reader["Salary"]);
                        employee.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        employee.Notes = Convert.ToString(reader["Notes"]);
                    }
                    con.Close();
                }
                return employee;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
