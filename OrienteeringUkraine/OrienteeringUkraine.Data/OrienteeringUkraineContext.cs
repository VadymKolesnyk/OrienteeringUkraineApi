using Microsoft.EntityFrameworkCore;
using OrienteeringUkraine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Data
{
    public partial class OrienteeringUkraineContext : DbContext
    {
        private readonly StreamWriter logStream = new StreamWriter("sqlserverlog.txt", true);
        private bool disposed = false;
        public OrienteeringUkraineContext(DbContextOptions<OrienteeringUkraineContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<LoginData> Logins { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<EventGroup> EventGroups { get; set; }
        public virtual DbSet<Group> Groups { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .LogTo(logStream.WriteLine);
        }
        public override void Dispose()
        {
            if (disposed)
            {
                return;
            }
            disposed = true;
            base.Dispose();
            logStream.Dispose();
            GC.SuppressFinalize(this);
        }
        public override async ValueTask DisposeAsync()
        {
            if (disposed)
            {
                return;
            }
            disposed = true;
            await base.DisposeAsync();
            await logStream.DisposeAsync();
        }
    }
}
