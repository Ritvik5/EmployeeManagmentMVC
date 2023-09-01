﻿using CommonLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmpRepo
    {
        private readonly IConfiguration configuration;
        private readonly string ConnectionString;

        public EmpRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        //To Add Employee
        public void AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
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
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
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

    }
}