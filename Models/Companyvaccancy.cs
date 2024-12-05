using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Companyvaccancy
    {
        public int cid { set; get; }
        [Required(ErrorMessage = "Enter the Job Title")]
        public string jtitle { set; get; }
        [Required(ErrorMessage = "Enter the Job Description")]
        public string jdesc { set; get; }
        [Required(ErrorMessage = "Enter the Skills")]
        public string skills { set; get; }
        [Required(ErrorMessage = "Enter the Experience")]
        public int exper { set; get; }
        [Required(ErrorMessage = "Enter the location")]
        public string location { set; get; }
        [Required(ErrorMessage = "Enter the Salary Range")]
        public string salary { set; get; }
        [Required(ErrorMessage = "Enter the Job Type")]
        public string jtype { set; get; }
        [Required(ErrorMessage = "Enter the Posting Date")]
        public DateTime posteddate { set; get; }
        [Required(ErrorMessage = "Enter the Last Date to Apply")]
        public DateTime lastdate { set; get; }
        [Required(ErrorMessage = "Enter the status")]
        public string status { set; get; }
        public string msg { set; get; }
    }
}