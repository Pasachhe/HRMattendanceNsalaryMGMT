using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResource.Models;

namespace HumanResource.Controllers
{
    public class EmployeeController : Controller, IDisposable //Inheritance:- releases unmanaged resources
    {

        HREntities db = new HREntities();


        // GET: Employee
        public ActionResult Employee()
        {

            List<Department> dlist = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(dlist, "DepartmentId", "DepartmentName");


            List<SiteUser> sitelist = db.SiteUsers.ToList();
            ViewBag.UserList = new SelectList(sitelist, "UserId", "UserName");

            List<EmployeeViewModel> listEmp = db.Employees.Where(x => x.IsDeleted == false).Select(x =>
                new EmployeeViewModel
                {
                    UserName = x.SiteUser.UserName,
                    DepartmentName = x.Department.DepartmentName,
                    Salary = x.Salary,
                    EmployeeId = x.EmployeeId
                }).ToList();
            ViewBag.EmployeeList = listEmp;



            return View();
        }





        // Polymorphism  (fn OvRi)

        [HttpPost]
        public ActionResult Employee(EmployeeViewModel model)
        {
            try
            {

                List<Department> list = db.Departments.ToList();
                ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

                if (model.EmployeeId > 0)
                {
                    //update
                    Employee emp = db.Employees.SingleOrDefault(x => x.EmployeeId == model.EmployeeId && x.IsDeleted == false);

                    emp.DepartmentId = model.DepartmentId;
                    emp.UserId = model.UserId;
                    emp.Salary = model.Salary;
                    db.SaveChanges();


                }
                else
                {
                    //Insert
                    Employee emp = new Employee();
                    emp.Salary = model.Salary;
                    emp.UserId = model.UserId;
                    emp.DepartmentId = model.DepartmentId;
                    emp.IsDeleted = false;

                    db.Employees.Add(emp);
                    db.SaveChanges();

                }
                return View(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }





        public JsonResult DeleteEmployee(int EmployeeId)
        {
            // SchoolEntities1 db = new SchoolEntities1();

            bool result = false;
            Employee emp = db.Employees.SingleOrDefault(x => x.IsDeleted == false && x.EmployeeId == EmployeeId);
            if (emp != null)
            {
                emp.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }





        public ActionResult AddEditEmployee(int EmployeeId)
        {
            
            List<Department> list = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

            List<SiteUser> Ulist = db.SiteUsers.ToList();
            ViewBag.SiteUserList = new SelectList(Ulist, "UserId", "UserName");

            EmployeeViewModel model = new EmployeeViewModel();

            if (EmployeeId > 0)
            {

                Employee emp = db.Employees.SingleOrDefault(x => x.EmployeeId == EmployeeId && x.IsDeleted == false);
                model.EmployeeId = emp.EmployeeId;
                model.DepartmentId = emp.DepartmentId;
                model.UserId = emp.UserId;
                model.Salary = emp.Salary;

            }
            return PartialView("PlusEmployee", model);
        }
    }
}