using Microsoft.EntityFrameworkCore;
using WAChoferes.Entities;

using WAChoferes.Models;

namespace WAChoferes
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Drivers> Driver { get; set; } 
        
        public DbSet<Autos> Auto { get; set; }
       
    }

}