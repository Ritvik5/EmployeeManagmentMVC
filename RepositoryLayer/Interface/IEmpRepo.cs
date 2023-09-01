using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmpRepo
    {
        void AddEmployee(EmployeeModel employeeModel);
        IEnumerable<EmployeeModel> GetAllEmployee();
    }
}
