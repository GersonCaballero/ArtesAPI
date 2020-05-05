using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArtesAPI.Models
{
    public class ArtesAPIContext : DbContext
    {
        public ArtesAPIContext() : base("name=ArtesAPIContext")
        {
        }

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Art> Arts { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<ValueLogo> ValueLogos { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<GarmentColor> GarmentColors { get; set; }
        public DbSet<Font> Fonts { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Login> logins { get; set; }
    }
}