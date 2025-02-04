using Microsoft.EntityFrameworkCore;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contexts;

public class PetPatFinalProjectDbContext : DbContext
{
    public DbSet<Product>Products { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetPatFinalProjectDbContext).Assembly);
    }
    public PetPatFinalProjectDbContext(DbContextOptions options) : base(options)
    {
    }
}
