using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCProject.Controllers
{
    public class JobdetailsController : Controller
    {
        MVC_projectEntities dbobj = new MVC_projectEntities();
        // GET: Jobdetails
        public ActionResult Jobsearch_pageload()
        {
            return View(Getdata());
        }
        private Jobdetails Getdata()
        {
            var joblist = new Jobdetails();
            List<string> lst = new List<string>();
            var job = dbobj.Vacc_table.ToList();
            foreach (var e in job)
            {
                var jobcls = new jsearch();
                jobcls.Job_Id = e.Job_id;
                jobcls.Company_Id = e.Comp_id;
                jobcls.Skills = e.Skills;
                jobcls.Experience = e.Experience;
                jobcls.Location=e.Location;
                jobcls.Job_status = e.Status;
                jobcls.Last_Date = e.Last_date.ToString();
                joblist.selectjob.Add(jobcls);
                var s = jobcls.Skills;
                lst.Add(s);
                TempData["ski"] = string.Join("", lst);
            }
            return joblist;
        }
        public ActionResult searchjob_click(Jobdetails clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Skills))
            {
                qry += "and Skills like '%" + clsobj.insertse. Skills + "%'";
            }
            if (clsobj.insertse.Experience >= 0)
            {
                 qry += " and Experience like '%" + clsobj.insertse. Experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Location))
            {
                qry += "and Location like '%" + clsobj.insertse.Location + "%'";
            }
            return View("Jobsearch_pageload", getdata1(clsobj, qry));
        }
        private Jobdetails getdata1(Jobdetails clsobj, string qry)
        {
            using(SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new Jobdetails();
                while (dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.Job_Id = Convert.ToInt32(dr["Job_id"].ToString());
                    jobcls.Company_Id = Convert.ToInt32(dr["Comp_id"].ToString());
                    jobcls.Skills = dr["Skills"].ToString();
                    jobcls.Experience = Convert.ToInt32(dr["Experience"].ToString());
                    jobcls.Location = dr["Location"].ToString();
                    jobcls.Job_status = dr["Status"].ToString();
                    jobcls.Last_Date= dr["Last_date"].ToString();
                    joblist.selectjob.Add(jobcls);

                }
                con.Close();
                return joblist;
            }
        }
    }
}