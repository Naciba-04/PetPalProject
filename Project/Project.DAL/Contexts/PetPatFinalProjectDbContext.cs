
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contexts;

public class PetPatFinalProjectDbContext : IdentityDbContext<AppUser>

{
    public DbSet<Product>Products { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    public PetPatFinalProjectDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetPatFinalProjectDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
