using Meetups.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Persistence.EntityTypeConfiguration
{
    internal class MeetupConfiguration : IEntityTypeConfiguration<Meetup>
    {
        public void Configure(EntityTypeBuilder<Meetup> builder)
        {
            builder.HasKey(meetup => meetup.Id);
            builder.HasIndex(meetup => meetup.Id).IsUnique();
            builder.Property(meetup => meetup.Title).HasMaxLength(100);
            builder.Property(meetup => meetup.Speaker).HasMaxLength(30);
        }
    }
}
