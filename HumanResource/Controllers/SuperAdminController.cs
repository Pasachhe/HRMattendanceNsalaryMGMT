using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResource.Models;
namespace HumanResource.Controllers
{
    public class SuperAdminController : Controller
    {
        private HREntities db = new HREntities();
        // GET: SuperAdmin
        public ActionResult SuperAdmin()
        {
            List<Department> Dlist = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(Dlist, "DepartmentId", "DepartmentName");

            List<SiteUser> Ulist = db.SiteUsers.ToList();
            ViewBag.SiteUserList = new SelectList(Ulist, "UserId", "UserName");

            List<AttendanceViewModel> Alist = db.Attendances.Select(x => new AttendanceViewModel
            {
                AttendanceId = x.AttendanceId,
                EmployeeName = x.Employee.SiteUser.UserName,
                Date = x.Date,
                InTime = x.InTime,
                OutTime = x.OutTime,
                WorkHours = x.WorkHours,
                Wage = x.Wage
            }).ToList();
            ViewBag.AttendanceList = Alist;

            return View();
        }
    }
}