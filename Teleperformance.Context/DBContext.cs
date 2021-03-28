using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teleperformance.Models.Entity;
using Teleperformance.Context.Helper; 

namespace Teleperformance.Context
{
    public class DBContext : IdentityDbContext
    {
        
        public DBContext()
        {
            
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        { }

       
        public virtual DbSet<Product> Products { get; set; }
  

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // for chain with base for Idntity 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed(); 
                 


           

        }

    }
}

