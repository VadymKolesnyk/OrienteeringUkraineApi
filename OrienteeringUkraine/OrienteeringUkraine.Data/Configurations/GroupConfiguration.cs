using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrienteeringUkraine.Domain.Entities;

namespace OrienteeringUkraine.Data.Configurations
{
    class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name)
                   .IsRequired()
                   .HasMaxLength(31);

            builder.HasAlternateKey(g => g.Name);
        }
    }
}
