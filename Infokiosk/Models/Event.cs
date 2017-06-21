using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Infokiosk.Models
{
    [PetaPoco.TableName("Events")]
    [PetaPoco.PrimaryKey("EventId")]
    public class Event
    {
        public long EventId { get; set; }
        public long EventCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Image> Images { get; set; }

        public virtual ICollection<EventAthletes> EventAthletes { get; set; }
    }
}