using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Infokiosk.Models
{
    public class Event
    {
        public int Id { get; set; }
        public EventCategory Category { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Achievement> Achievements { get; set; }
        public List<Image> Images { get; set; }
    }
}