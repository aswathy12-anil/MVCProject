using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Models
{
    public class CompanyregController : Controller
    {
        MVC_projectEntities dbobj = new MVC_projectEntities();
        // GET: Companyreg
        public ActionResult Insertcomp_Pageload()
        {
            return View();
        }

        public ActionResult Insertcomp_Click(Companyreg clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_maxlogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }

                dbobj.sp_comp(regid, clsobj.name, clsobj.email, clsobj.phone,clsobj.location, clsobj.website);
                dbobj.sp_logininsert(regid, clsobj.username, clsobj.pswd, "company");
                clsobj.cdmsg = "Successfully Registered";
                return View("Insertcomp_Pageload", clsobj);
            }
            return View("Insertcomp_Pageload", clsobj);
        }
    }
}
