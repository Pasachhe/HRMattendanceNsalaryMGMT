using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResource.Models;

namespace HumanResource.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public JsonResult LoginUser(RegistrationViewModel model)
        {

            using (HREntities db= new HREntities())
            {

                SiteUser user = db.SiteUsers.SingleOrDefault(x => x.EmailId == model.EmailId && x.Password == model.Password);
                string result = "fail";

                if (user != null)
                {
                    var id = Convert.ToString(Guid.NewGuid());
                    var InTime = DateTime.Now;

                    Employee emp = db.Employees.SingleOrDefault(x => x.UserId == user.UserId);

                    var H1 = Convert.ToInt32(InTime.Hour);
                    var M1 = Convert.ToInt32(InTime.Minute); ;
                    var M11 = H1 * 60 + M1;

                    Session["UserId"] = user.UserId;
                    Session["UserName"] = user.UserName;
                   

                    Session["AttendanceId"] = id;
                    Session["Salary"] = emp.Salary;
                    Session["M11"] = M11;



                    Attendance att = new Attendance();
                    att.AttendanceId = id;
                    att.EmployeeId = emp.EmployeeId;
                    att.Date = DateTime.Today.Date.ToString("MM/dd/yyyy");
                    att.InTime = Convert.ToString("H1"+":"+"M1");
                    att.OutTime = null;
                    att.WorkHours = null;
                    att.Wage = null;
                    db.Attendances.Add(att);
                    db.SaveChanges();

                    if (user.RoleId == 3)
                    {
                        result = "GeneralUser";
                    }
                    else if (user.RoleId == 2)
                    {
                        result = "SuperAdmin";
                    }
                    else if (user.RoleId == 1)
                    {
                        result = "Admin";
                    }

                    
                }

                return Json(result, JsonRequestBehavior.AllowGet); // to allow HTTP get request to HTTPpost
            }


            
        }
    }
}