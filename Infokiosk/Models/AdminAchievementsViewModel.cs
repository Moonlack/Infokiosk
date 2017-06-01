using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class AdminAchievementsViewModel
    {
        public List<Athlete> Athletes { get; set; }
        public List<Prize>  Prizes { get; set; }
        public List<Event>  Events { get; set; }

        public List<Achievement> Achievements { get; set; }
        public Achievement Achievement { get; set; }        
    }
}