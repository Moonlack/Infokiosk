using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class AdminSportsFacilitiesViewModel
    {
        public List<SportsFacility> SportsFacilities { get; set; }
        public SportsFacility SportsFacility { get; set; }     
        public List<SportsFacilityCategory> Categories { get; set; }

        public List<Image> Images { get; set; }
    }
}