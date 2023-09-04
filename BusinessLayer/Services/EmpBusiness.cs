using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmpBusiness : IEmpBusiness
    {
        private readonly IEmpRepo empRepo;

        public EmpBusiness(IEmpRepo empRepo)
        {
            this.empRepo = empRepo;
        }

        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                return empRepo.AddEmployee(employeeModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteEmployee(int empId)
        {
            try
            {
                return empRepo.DeleteEmployee(empId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            try
            {
                return this.empRepo.GetAllEmployee();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public EmployeeModel GetById(int empId)
        {
            try
            {
                return empRepo.GetById(empId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                return empRepo.UpdateEmployee(employeeModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
