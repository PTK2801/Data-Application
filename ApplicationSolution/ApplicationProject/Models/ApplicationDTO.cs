using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;

namespace ApplicationProject.Models
{
    public class ApplicationDTO
    {

        public ArtworkDTO ArtworkModel { get; set; }
        public ClientDTO ClientModel { get; set; }
        public JobDTO JobModel { get; set; }
        public OrderDTO OrderModel { get; set; }

    }

    public class ArtworkDTO
    {
        public int ArtworkId { get; set; }
        public string Title { get; set; }
        public string NameOfCreator { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Description { get; set; }
        public int JobId { get; set; }
        public virtual Job Job { get; set; }
    }

    public class ClientDTO
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
    }

    public class JobDTO
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
    public class OrderDTO
    {
        public int OrderId { get; set; }

        [Display(Name = "Order Number")]
        [Required]
        public int OrderNumber { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string Status { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

    }


}