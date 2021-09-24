using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Data.Configurations;
using NLayerProject.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data
{
    public class AppDbContext:IdentityDbContext<UserApp,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> context):base(context)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRefreshToken> userRefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Console.WriteLine(GetType().Assembly);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.ApplyConfiguration(new ProductSeed(new List<int>() {1,2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new List<int>() { 1, 2 }));

            modelBuilder.Entity<Person>().HasKey(i => i.Id);
            modelBuilder.Entity<Person>().Property(i => i.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(i => i.Name).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Person>().Property(i => i.SurName).IsRequired().HasMaxLength(25);
        }
    }
}
