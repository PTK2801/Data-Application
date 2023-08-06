using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationProject.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public List<Job> Jobs { get; set; }
    }
}