using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations;

public class WorkerDepartmentConfiguration : IEntityTypeConfiguration<WorkerDepartment>
{
    public void Configure(EntityTypeBuilder<WorkerDepartment> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(64)
            .IsRequired();
    }
}
