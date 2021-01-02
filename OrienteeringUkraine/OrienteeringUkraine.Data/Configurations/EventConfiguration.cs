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
    class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Title)
                   .IsRequired();

            builder.Property(e => e.Date)
                   .HasColumnType("date");

            builder.HasIndex(e => e.Date);

            builder.Property(e => e.Location)
                   .HasMaxLength(255);

            builder.Property(e => e.IsApplicationOpen)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.HasOne(e => e.Region)
                   .WithMany(r => r.Events)
                   .HasForeignKey(e => e.RegionId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Events_Regions");

            builder.HasOne(e => e.Organizer)
                   .WithMany(o => o.Events)
                   .HasForeignKey(e => e.OrganizerLogin)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Events_Users");

            builder.HasMany(e => e.Groups)
                   .WithMany(g => g.Events)
                   .UsingEntity<EventGroup>(
                        j => j.HasOne(eg => eg.Group)
                              .WithMany(g => g.EventGroups)
                              .HasForeignKey(eg => eg.GroupId)
                              .OnDelete(DeleteBehavior.Cascade)
                              .HasConstraintName("FK_EventGroups_Groups"),
                        j => j.HasOne(eg => eg.Event)
                              .WithMany(e => e.EventGroups)
                              .HasForeignKey(eg => eg.EventId)
                              .OnDelete(DeleteBehavior.Cascade)
                              .HasConstraintName("FK_EventGroups_Events"),
                        j => j.HasAlternateKey(eg => new { eg.EventId, eg.GroupId })
                    );
        }
    }
}
