using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmpRepo
    {
        bool AddEmployee(EmployeeModel employeeModel);
        IEnumerable<EmployeeModel> GetAllEmployee();
        EmployeeModel GetById(int empId);
        bool UpdateEmployee(EmployeeModel employeeModel);
        bool DeleteEmployee(int empId);
    }
}
