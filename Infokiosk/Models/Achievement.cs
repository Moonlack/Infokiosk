using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [TableName("Achievements")]
    [PrimaryKey("AchievementId")]
    [ExplicitColumns]
    public class Achievement
    {
        [Column] public long AchievementId { get; set; }

        [Column] public int AthleteId { get; set; }
        public Athlete Athlete { get; set; }

        [Column] public int EventId { get; set; }
        public Event Event { get; set; }

        [Column] public string KindOfSport { get; set; }

        [Column] public int PrizeId { get; set; }
        public Prize Prize { get; set; }
    }
}