using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResource.Models;

namespace HumanResource.Controllers
{

    public class RegistrationController : Controller
    {

        HREntities db = new HREntities();


        // GET: Registration
        public ActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public JsonResult RegisterUser(RegistrationViewModel model)
        {
          

                SiteUser siteUser = new SiteUser();

                siteUser.UserName = model.UserName;

                siteUser.RoleId = model.RoleId;
                siteUser.EmailId = model.EmailId;
                siteUser.Password = model.Password;
                siteUser.Address = model.Address;

                db.SiteUsers.Add(siteUser);
                db.SaveChanges();
            




            return Json("Success", JsonRequestBehavior.AllowGet);
        }

    }
}