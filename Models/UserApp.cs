﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class UserApp
    {
        public int jid { set; get; }
        public int uid { set; get; }
        [Required(ErrorMessage = "Enter the Application Date")]
        public DateTime appldate { set; get; }
        public string resume { set; get; }
        public string sts { set; get; }
        public string msg { set; get; }
    }
}