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
    class LoginDataConfiguration : IEntityTypeConfiguration<LoginData>
    {
        public void Configure(EntityTypeBuilder<LoginData> builder)
        {
            builder.HasKey(l => l.Login);

            builder.Property(l => l.HashedPassword)
                   .IsRequired();

            builder.HasOne(l => l.User)
                   .WithOne(u => u.LoginData)
                   .HasForeignKey<User>(u => u.Login)
                   .HasConstraintName("FK_LoginData_Users");
        }
    }
}
