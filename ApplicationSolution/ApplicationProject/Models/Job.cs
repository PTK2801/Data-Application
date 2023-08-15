using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProject.Models
{
    public class Job
    {
        public int JobID { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        
        [StringLength(50, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }


        [Range(17000, 200000)]
        [DataType(DataType.Currency)]
        [Required]
        public int Salary { get; set; }

        [Required]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public List<Artwork> Artworks { get; set; }
    }
}