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
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Login);

            builder.HasIndex(u => u.Surname);

            builder.Property(u => u.Name)
                   .HasMaxLength(50);

            builder.Property(u => u.Surname)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.BirthDate)
                   .HasColumnType("date");

            builder.HasOne(u => u.LoginData)
                   .WithOne(l => l.User)
                   .HasForeignKey<LoginData>(l => l.Login)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_Users_Logins");

            builder.HasOne(u => u.Role)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.RoleId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Users_Roles");

            builder.HasOne(u => u.Region)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.RegionId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Users_Regions");

            builder.HasOne(u => u.Club)
                   .WithMany(c => c.Users)
                   .HasForeignKey(u => u.ClubId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Users_Clubs");
            
        }
    }
}
