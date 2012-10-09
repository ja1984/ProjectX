using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Models
{
    public class pdf
    {
        public int id { get; set; }
        public UserViewModel User { get; set; }
        public string Message { get; set; }
        public string Adress { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public int PhoneNumber { get; set; }
        public int Cellphone { get; set; }
    }
}