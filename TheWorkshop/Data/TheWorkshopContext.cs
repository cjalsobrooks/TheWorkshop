using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheWorkshop.Models;

namespace TheWorkshop.Data
{
    public class TheWorkshopContext : DbContext
    {
        public TheWorkshopContext (DbContextOptions<TheWorkshopContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasDiscriminator<string>("ItemType")
                .HasValue<CalendarEvent>("Event")
                .HasValue<ToDoTask>("Task")
                .HasValue<Deadline>("Deadline");
        }
        public DbSet<TheWorkshop.Models.Deadline> Deadline { get; set; } = default!;
        public DbSet<TheWorkshop.Models.CalendarEvent> Event { get; set; } = default!;
    }
}
