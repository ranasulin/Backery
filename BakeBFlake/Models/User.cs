using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeBFlake.Models
{
    public class User
    {
        public Int32 Id { get; set; }
        public String Name { get; set;}
        public String LastName { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String Password { get; set; }
        public Boolean Prefered { get; set;}
    }
}