using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.Property(x => x.FullName)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(x => x.ProfileImageUrl)
           .HasMaxLength(255)
           .IsRequired();

        builder.HasOne(x => x.WorkerDepartment)
            .WithMany(x => x.Workers)
            .HasForeignKey(x => x.WorkerDepartmentId).OnDelete(DeleteBehavior.Restrict);
    }
}
