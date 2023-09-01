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
    }
}
