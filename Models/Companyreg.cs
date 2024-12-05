using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Companyreg
    {
        public int aid { set; get; }
        [Required(ErrorMessage = "Enter the name")]
        public string name { set; get; }
        [Required(ErrorMessage = "Enter valid email id")]
        public string email { set; get; }
        [Required(ErrorMessage = "Enter the phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string phone { set; get; }
        [Required(ErrorMessage = "Enter the location")]
        public string location { set; get; }
        [Required(ErrorMessage = "Enter the website address")]
        public string website { set; get; }
        public string username { set; get; }
        public string pswd { set; get; }
        [Compare("pswd", ErrorMessage = "Password mismatch")]
        public string conpswd { set; get; }
        public string cdmsg { set; get; }
    }
}