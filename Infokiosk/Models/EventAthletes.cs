using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class EventAthletes
    {
        //public int Id { get; set; }
        //public int AthleteId { get; set; }
        //public Athlete Athlete { get; set; }
        //public List<Event> Events { get; set; }
        [Key, Column(Order = 0)]
        public int EventId { get; set; }
        [Key, Column(Order = 1)]
        public int AthleteId { get; set; }
        
        public virtual Event Event { get; set; }
        public virtual Athlete Athlete { get; set; }
    }

}