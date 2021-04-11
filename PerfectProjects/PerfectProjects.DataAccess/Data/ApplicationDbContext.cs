using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerfectProjects.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectProjects.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShortDescription> ShortDescriptions { get; set; }
        public DbSet<Description> Descriptions { get; set; }
    }
}
