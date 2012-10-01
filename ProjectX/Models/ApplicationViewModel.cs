using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectX.Model.Entities;

namespace ProjectX.Models
{
    public class ApplicationViewModel
    {
        public Application Application { get; set; }
        public List<Project> Projects { get; set; }
    }
}