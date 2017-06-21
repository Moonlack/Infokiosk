using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    [PetaPoco.TableName("Athltetes")]
    [PetaPoco.PrimaryKey("AthleteId")]
    public class Athlete
    {
        public long AthleteId { get; set; }
        public string Initials { get; set; }
        public string Description { get; set; }

        public List<Achievement> Achievements { get; set; }
        public List<Image> Images { get; set; }

        public virtual ICollection<EventAthletes> EventAthletes { get; set; }
    }
}