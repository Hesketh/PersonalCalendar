using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RestAPI.Models;

namespace RestAPI.Context
{
    public class BaseContext : DbContext
    {
        protected DbSet<CalendarUser> CalendarUsers { get; set; }
        protected DbSet<CalendarEvent> Events { get; set; }
        protected DbSet<Calendar> Calendars { get; set; }
        protected DbSet<User> Users { get; set; }

        public BaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //CalendarUser composite pkey
            builder.Entity<Models.CalendarUser>()
                .HasKey(x => new { x.Username, x.CalendarID });

            //Many calendar users, one calendar
            builder.Entity<Models.CalendarUser>()
                .HasOne(x => x.Calendar)
                .WithMany(x => x.CalendarUsers)
                .HasForeignKey(x => x.CalendarID);

            //Many calendar users, one user
            builder.Entity<Models.CalendarUser>()
                .HasOne(x => x.User)
                .WithMany(x => x.CalendarUsers)
                .HasForeignKey(x => x.Username);

            //One privilege, one calendar user
            builder.Entity<Models.CalendarUser>()
                .HasOne(x => x.Privilege)
                .WithOne(x => x.CalendarUser)
                .HasForeignKey<Models.CalendarUser>(x => x.PrivilegeKey);

            //One calendar, many events
            builder.Entity<Models.CalendarEvent>()
                .HasOne(x => x.Calendar)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.CalendarID);
        }
    }
}
