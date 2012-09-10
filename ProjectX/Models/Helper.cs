using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Models
{
    public class Helper : Member
    {
        public Position Position { get; set; }        
    }


    public enum Position
    {
        Developer,
        Designer,
        Tester
    }

}