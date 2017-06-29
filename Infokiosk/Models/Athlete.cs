using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [PetaPoco.TableName("Athltetes")]
    [PetaPoco.PrimaryKey("AthleteId")]
    [ExplicitColumns]
    public class Athlete
    {
        [Column] public long AthleteId { get; set; }
        [Column] public string Initials { get; set; }
        [Column] public string Description { get; set; }

        public List<Achievement> Achievements { get; set; }
        public List<Image> Images { get; set; }

        public virtual ICollection<EventAthletes> EventAthletes { get; set; }
    }
}