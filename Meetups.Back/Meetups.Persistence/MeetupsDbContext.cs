using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meetups.Application.Interfaces;
using Meetups.Domain;
using Meetups.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Meetups.Persistence
{
    public class MeetupsDbContext : DbContext, IMeetupsDbContext
    {
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<User> Users { get; set; }

        public MeetupsDbContext(DbContextOptions<MeetupsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MeetupConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
