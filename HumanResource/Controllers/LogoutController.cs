using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResource.Models;

namespace HumanResource.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
      

        public ActionResult Logout()
        {

            using (HREntities db = new HREntities())
            {
                var id = Convert.ToString(Session["AttendanceId"]);
                Attendance att = db.Attendances.SingleOrDefault(x => x.AttendanceId == id);



                var outTime = DateTime.Now;
                var In = DateTime.Parse(Session["InTime"].ToString());
                var inMins = Convert.ToInt32(Session["M11"]);

                var h2 = outTime.Hour;
                var m2 = outTime.Minute;

                var outMins = h2 * 60 + m2;
                var salry = Convert.ToInt32(Session["Salary"]);
                double workTime = (outMins - inMins)/ 60;
                double daySalary = workTime * salry;

                var result = outTime - In;



                //now Update DB

                //att.OutTime = DateTime.Now.ToString("HH:mm"); //I will make this after changing its type to String Type
                att.OutTime = DateTime.Now.ToString("HH:MM");
                att.WorkHours = workTime;
                att.Wage = daySalary;
                db.SaveChanges();
                Session.Clear();
                Session.Abandon();

            }

            return RedirectToAction(actionName: "Login",controllerName: "Login");
        }
    }
}