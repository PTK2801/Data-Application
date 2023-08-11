using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationProject.Models
{
    public class Artwork
    {
        public int ArtworkID { get; set; }
        public string Title { get; set; }
        public string NameOfCreator { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Description { get; set; }
        public int JobID { get; set; }
        public virtual Job Job { get; set; }
    }
}