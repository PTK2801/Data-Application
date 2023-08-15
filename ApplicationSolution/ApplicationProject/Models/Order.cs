using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;

namespace ApplicationProject.Models
{
    
    public class Order
    {
        public int OrderID { get; set; }

        [Display(Name = "Order Number")]
        [Required]
        public int OrderNumber { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}" , ApplyFormatInEditMode = true)]
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public List<Job> Jobs { get; set; }

    }
}
public enum TheStatus
{
    Ready, In_Progress
}