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

        public void AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                empRepo.AddEmployee(employeeModel);
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
    }
}
