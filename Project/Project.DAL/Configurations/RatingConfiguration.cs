using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        
           builder.HasOne(r => r.AppUser)
           .WithMany(u => u.Ratings)
           .HasForeignKey(r => r.AppUserId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}

