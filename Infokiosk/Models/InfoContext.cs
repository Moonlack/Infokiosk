using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class InfoContext : DbContext
    {
        //public BookContext(): base("DefaultConnection")
        //{ }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<KindOfSport> KindsOfSports { get; set; }
        public DbSet<SportsFacility> SportsFacilities { get; set; }
        public DbSet<MassSport> MassSports { get; set; }
        public DbSet<Prize> Prizes { get; set; }
    }
}