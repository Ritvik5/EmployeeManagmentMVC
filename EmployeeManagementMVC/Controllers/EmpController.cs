using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementMVC.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmpBusiness empBusiness;
        public EmpController(IEmpBusiness empBusiness)
        {
            this.empBusiness = empBusiness;
        }

        public IActionResult Index()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = empBusiness.GetAllEmployee().ToList();

            return View(lstEmployee);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                empBusiness.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int employeeId)
        {
            try
            {
                EmployeeModel employee = empBusiness.GetById(employeeId);
                if (employee.EmployeeId == 0)
                {
                    TempData["errorMessage"] = $"Employee deatils not found with id: {employeeId}";
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Edit(EmployeeModel employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["errorMessage"] = "Model data is invalid";
                    return View();
                }
                bool result = empBusiness.UpdateEmployee(employee);
                if(!result)
                {
                    TempData["errorMessage"] = "Unable to update Employee";
                    return View();
                }
                TempData["successMessage"] = "Employee details updated";
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Delete(int employeeId)
        {
            try
            {
                EmployeeModel employee = empBusiness.GetById(employeeId);
                if (employee.EmployeeId == 0)
                {
                    TempData["errorMessage"] = $"Employee deatils not found with id: {employeeId}";
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int EmployeeId)
        {
            try
            {
                bool result = empBusiness.DeleteEmployee(EmployeeId);
                if (!result)
                {
                    TempData["errorMessage"] = "Unable to Delete Employee";
                    return View();
                }
                TempData["successMessage"] = "Employee details deleted";
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
