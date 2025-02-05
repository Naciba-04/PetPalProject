using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations;

public class PetTypeConfiguration : IEntityTypeConfiguration<PetType>
{
    public void Configure(EntityTypeBuilder<PetType> builder)
    {
        builder.Property(x => x.Name)
                    .HasMaxLength(64)
                    .IsRequired();
    }
}
