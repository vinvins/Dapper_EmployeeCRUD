using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeTest.Models;
using Dapper;

namespace EmployeeTest.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<Employee> employees= DapperORM.ReturnList<Employee>("GetAllEmployees");
            return View(employees);
        }

        
        public ActionResult Create(int EmployeeID=0)
        {           
            return View();
        }

      
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", employee.EmployeeID);
            param.Add("@Name", employee.Name);
            param.Add("@Age", employee.Age);
            param.Add("@Salary", employee.Salary);
            DapperORM.ReturnNothing("AddorEditEmployee",param);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int ID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", ID);
            Employee employee = DapperORM.ReturnSingleRow<Employee>("GetEmployeeByID", param);
            return View(employee);
        }

        public ActionResult Edit(int ID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", ID);
            Employee employee = DapperORM.ReturnSingleRow<Employee>("GetEmployeeByID", param);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", employee.EmployeeID);
            param.Add("@Name", employee.Name);
            param.Add("@Age", employee.Age);
            param.Add("@Salary", employee.Salary);
            DapperORM.ReturnNothing("AddorEditEmployee", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", ID);
            Employee employee = DapperORM.ReturnSingleRow<Employee>("GetEmployeeByID", param);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee,int ID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", ID);
            DapperORM.ReturnNothing("DeleteEmployeeByID", param);
            return RedirectToAction("Index");
        }
    }
}