using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Models
{
    public class ApplicationApplyModel
    {
        public int RoleId { get; set; }
        public int ProjectId { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }

    }
}