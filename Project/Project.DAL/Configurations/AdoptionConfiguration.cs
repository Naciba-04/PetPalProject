using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Enums;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations;

public class AdoptionConfiguration : IEntityTypeConfiguration<Adoption>
{
    public void Configure(EntityTypeBuilder<Adoption> builder)
    {
        builder.Property(a => a.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

        builder.Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.Salary)
            .HasPrecision(18, 2) 
            .IsRequired();

        builder.Property(a => a.HasHouse)
            .IsRequired(); 

        builder.Property(a => a.ReservStatus)
            .HasDefaultValue(ReservStatus.Pending);
    }
}
