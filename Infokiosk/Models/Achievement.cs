using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
namespace Infokiosk.Models
{
    [PetaPoco.TableName("Achievements")]
    [PetaPoco.PrimaryKey("Achievement_id")]
    public class Achievement
    {
        public long AchievementId { get; set; }
        public int AthleteId { get; set; }
        public Athlete Athlete { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string KindOfSport { get; set; }
        public int PrizeId { get; set; }
        public Prize Prize { get; set; }
    }
}