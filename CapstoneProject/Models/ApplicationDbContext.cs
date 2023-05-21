using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;

namespace CapstoneProject.Models
{
  public class ApplicationDbContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BSC-PG02KEHR\\SQLEXPRESS;Database=CapstroneProjectDb;Integrated Security=true;TrustServerCertificate=true");
        }
    }
}
