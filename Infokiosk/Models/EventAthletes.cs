using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    [PetaPoco.TableName("EventAthletes")]
    public class EventAthletes
    {
        [Key, Column(Order = 0)]
        public long EventId { get; set; }
        [Key, Column(Order = 1)]
        public long AthleteId { get; set; }
        
        public virtual Event Event { get; set; }
        public virtual Athlete Athlete { get; set; }
    }

}