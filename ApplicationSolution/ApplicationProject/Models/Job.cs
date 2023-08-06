using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationProject.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public List<Artwork> Artworks { get; set; }
    }
}