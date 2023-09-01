using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmpBusiness
    {
        void AddEmployee(EmployeeModel employeeModel);
        IEnumerable<EmployeeModel> GetAllEmployee();
    }
}
