using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrienteeringUkraine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Data.Configurations
{
    class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasOne(a => a.User)
                   .WithMany(u => u.Applications)
                   .HasForeignKey(a => a.UserLogin)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_Applications_Users");

            builder.HasOne(a => a.EventGroup)
                   .WithMany(eg => eg.Applications)
                   .HasForeignKey(a => a.EventGroupId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Applications_EventGroups");

            builder.Property(a => a.UserLogin)
                   .IsRequired();

            builder.HasAlternateKey(a => new { a.UserLogin, a.EventGroupId });
        }
    }
}
