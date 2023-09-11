using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProject.Models
{
    public class Artwork
    {
        public int ArtworkId { get; set; }
        
        
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Name of Creator")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,50}$", ErrorMessage = "Name of Creator field should only contain between 2 and 50 Letters and spaces included.")]
        [Required]
        public string NameOfCreator { get; set; }

        
        [Display(Name = "Date of Creation")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateOfCreation { get; set; }

        
        [StringLength(50, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }


        [Required(ErrorMessage = "The Job Title field is required.")]
        public int JobId { get; set; }

        public virtual Job Job { get; set; }

        public static implicit operator List<Artwork>(Artwork v)
        {
            throw new NotImplementedException();
        }
    }
}