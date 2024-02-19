using CalendarManager.Entities.Entities;
using CalendarManager.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManager.Infraestructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Event> Event { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new EnumToNumberConverter<EventType, int>();

            modelBuilder.Entity<Event>()
                .Property(e => e.Type)
                .HasConversion(converter);
        }
    }
}
