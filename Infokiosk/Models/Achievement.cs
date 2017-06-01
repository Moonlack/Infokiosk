using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
namespace Infokiosk.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public int AthleteId { get; set; }
        public Athlete Athlete { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string KindOfSport { get; set; }
        public int PrizeId { get; set; }
        public Prize Prize { get; set; }
    }
}