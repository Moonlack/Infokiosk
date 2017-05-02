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
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Achievement> Achievements { get; set; }
        }
}