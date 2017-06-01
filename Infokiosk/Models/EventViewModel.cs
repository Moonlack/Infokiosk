using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public List<Achievement> Achievements { get; set; }
        public List<Athlete> Athletes { get; set; }
        }
}