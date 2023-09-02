using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProject.Models
{
    public class Client
    {
        public int ClientId { get; set; }


        [RegularExpression(@"^[a-zA-Z''-'\s]{2,50}$", ErrorMessage = "Name field should only contain between 2 and 50 Letters and spaces included.")]
        [Required]
        public string Name { get; set; }


        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateOfBirth { get; set; }


        [StringLength(50, MinimumLength = 10)]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Phone Number field should only contain 11 numbers.")]
        [Required]
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; }
    }
}