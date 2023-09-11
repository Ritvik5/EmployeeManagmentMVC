using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("Emp/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel employee)
        {
            string message = TempData["errorMessage"].ToString();
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
        [HttpPost("Emp/Edit{employee}")]
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
                    TempData["errorMessage"] = $"Employee deatils not found with id : {employeeId}.";
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost("Emp/Delete"),ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int employeeId)
        {
            try
            {
                bool result = empBusiness.DeleteEmployee(employeeId);
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
        [HttpGet]
        public IActionResult Details()
        {
            try
            {
                int empId = (int)HttpContext.Session.GetInt32("EmployeeId");
                string empName = HttpContext.Session.GetString("Name");
                EmployeeModel employee = empBusiness.GetById(empId);
                if (employee.EmployeeId == 0)
                {
                    TempData["errorMessage"] = $"Employee deatils not found with id: {empId}";
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            var employeeLogin = new EmployeeLogin();
            return View(employeeLogin);
        }
        [HttpPost]
        public IActionResult Login([Bind] EmployeeLogin employeeLogin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["errorMessage"] = "Model data is invalid";
                    return View();
                }
                EmployeeModel employee = empBusiness.LogInEmployee(employeeLogin);
                if (employee.EmployeeId == 0)
                {
                    TempData["errorMessage"] = $"Employee deatils not found with id : {employeeLogin.EmployeeId} .Please Register!!";
                    return RedirectToAction("Create");
                }
                if (employee != null)
                {
                    HttpContext.Session.SetInt32("EmployeeId", employee.EmployeeId);
                    HttpContext.Session.SetString("Name", employee.Name);
                    return RedirectToAction("Details");
                }
                else
                {
                    return View(employeeLogin);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
