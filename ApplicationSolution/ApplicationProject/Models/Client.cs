using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationProject.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; }
    }
}