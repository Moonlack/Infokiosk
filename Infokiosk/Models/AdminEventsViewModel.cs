using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class AdminEventsViewModel
    {
        public List<Event> Events { get; set; }
        public Event Event { get; set; }        
    }
}