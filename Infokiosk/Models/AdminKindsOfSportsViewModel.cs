using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class AdminKindsOfSportsViewModel
    {
        public List<KindOfSport> KindsOfSports { get; set; }
        public KindOfSport KindOfSport { get; set; }
    }
}