using ApplicationProject.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;

namespace ApplicationProject.DAL
{
    public class WorkContext : DbContext
    {
        public WorkContext() : base("WorkContext")
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }

        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Order> Orders { get; set; }

       

    }
    
}