using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class Athlete
    {
        public int Id{ get; set; }
        public string Initials { get; set; }
        
        public List<Achievement> Achievements { get; set; }
    }
}