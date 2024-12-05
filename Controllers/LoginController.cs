using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class LoginController : Controller
    {
        MVC_projectEntities dbobj = new MVC_projectEntities();
        // GET: Login
        public ActionResult Login_Pageload()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            return View(new Login());
        }

        public ActionResult CompanyHome()
        {
            return View(new Companyvaccancy());
        }


        public ActionResult SubmitCompanyVacancy(Companyvaccancy clsobj)
        {
            if (ModelState.IsValid)
            {
                int CompId = Convert.ToInt32(Session["usid"]);
                clsobj.cid = CompId;

                dbobj.sp_vaccancy(clsobj.cid, clsobj.jtitle, clsobj.jdesc, clsobj.skills, clsobj.exper, clsobj.location, clsobj.salary, clsobj.jtype, clsobj.posteddate, clsobj.lastdate, clsobj.status);
                clsobj.msg = "Successfully Inserted";
                return RedirectToAction("CompanyHome");
            }
            return RedirectToAction("CompanyHome", clsobj);
        }

        public ActionResult Login_Click(Login clsobj)
        {
            var val = dbobj.sp_logincountId(clsobj.usna, clsobj.pswd).Single();
            if (val == 1)
            {
                var uid = dbobj.sp_loginId(clsobj.usna, clsobj.pswd).FirstOrDefault();
                Session["usid"] = uid;
                var lt = dbobj.sp_logintype(clsobj.usna, clsobj.pswd).FirstOrDefault();
                if (lt == "User")
                {
                    return RedirectToAction("UserHome");
                }
                else if (lt == "company")
                {
                    return RedirectToAction("CompanyHome");
                }
            }
            else
            {
                ModelState.Clear();
                clsobj.msg = "Invalid Login";
                return View("Login_Pageload", clsobj);
            }
            return View("Login_Pageload", clsobj);
        }
    }
}