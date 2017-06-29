using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [TableName("EventAthletes")]

    public class EventAthletes
    {
        //[Key, Column(Order = 0)]
        [PetaPoco.Column] public long EventId { get; set; }
        //[Key, Column(Order = 1)]
        [PetaPoco.Column] public long AthleteId { get; set; }
        
        public virtual Event Event { get; set; }
        public virtual Athlete Athlete { get; set; }
    }

}