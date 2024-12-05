using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Jobdetails
    {
        public Jobdetails()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }
        public jsearch insertse { get; set; }
        public List<jsearch> selectjob { get; set; }
    }
    public class jsearch
    {
        public int Job_Id { get; set; }
        public int Company_Id { get; set; }
        public string Skills { get; set; }
        public int Experience { get; set; }
        public string Location { get; set; }
        public string Job_status { get; set; }
        public string Last_Date { get; set; }
        public string jobmsg { get; set; }
        
    }
}