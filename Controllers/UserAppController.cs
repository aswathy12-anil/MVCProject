using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using System.IO;

namespace MVCProject.Controllers
{
    public class UserAppController : Controller
    {
        MVC_projectEntities dbobj = new MVC_projectEntities();
        // GET: UserApp
        public ActionResult ApplyCV_Load()
        {
            return View();
        }
        public ActionResult Applycv_click(UserApp clsobj, HttpPostedFileBase file, int jid)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/resume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\resume", fname);
                    clsobj.resume =fullpath; //
                }
                int UserId = Convert.ToInt32(Session["uid"]);
                clsobj.uid = UserId;
                clsobj.jid =jid;
                dbobj.sp_UserApp(clsobj.jid, clsobj.uid, clsobj.appldate, clsobj.resume, "Applied");
                clsobj.msg = "Applied Successfully";
                return View("ApplyCV_Load", clsobj);
            }
            return View("ApplyCV_Load", clsobj);
        }
    }
}