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

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(r => r.FullName)
           .IsRequired()
           .HasMaxLength(100);

        builder.Property(r => r.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(r => r.Date)
            .IsRequired()
            .HasColumnType("date"); 

        builder.Property(r => r.StartTime)
            .IsRequired()
            .HasColumnType("time"); 

        builder.Property(r => r.EndTime)
            .IsRequired()
            .HasColumnType("time");

        builder.Property(r => r.ReservStatus)
            .HasDefaultValue(ReservStatus.Pending)
            .IsRequired();

        builder.HasOne(r => r.PetType)
            .WithMany(r=>r.Reservations)
            .HasForeignKey(r => r.PetTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.PetService)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.PetServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
