using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Title)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(x => x.CoverImageUrl)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(x => x.Quantity)
            .IsRequired()
            .HasDefaultValue(0)
            .HasAnnotation("Range", "0-1000");
        
        builder.Property(x => x.NewPrice)
            .HasColumnType("decimal(18,2)");
        builder.Property(x => x.OldPrice)
           .HasColumnType("decimal(18,2)")
           .IsRequired();
        builder.HasOne(x => x.Department)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);


    }
}
