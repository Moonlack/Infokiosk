using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Caption { get; set; }

        public Athlete  Athlete { get; set; }
        public Exhibit Exhibit { get; set; }
        public Event Event { get; set; }
        public KindOfSport KindOfSport { get; set; }
        public SportsFacility SportsFacility { get; set; }
    }
}