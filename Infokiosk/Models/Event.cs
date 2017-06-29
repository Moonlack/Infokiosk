using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [TableName("Events")]
    [PrimaryKey("EventId")]
    public class Event
    {
        [Column] public long EventId { get; set; }
        [Column] public long EventCategoryId { get; set; }
        [Column] public string Name { get; set; }
        [Column] public string Description { get; set; }

        public List<Image> Images { get; set; }

        public virtual ICollection<EventAthletes> EventAthletes { get; set; }
    }
}