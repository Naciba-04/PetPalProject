using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.Property(x => x.Title)
           .HasMaxLength(255)
           .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(x => x.Color)
            .HasMaxLength(64)
            .IsRequired();
        builder.Property(x => x.CoverImageUrl)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(x => x.Weight)
            .HasColumnType("decimal(10,2)");
    }
}
