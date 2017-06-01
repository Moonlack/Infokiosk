using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class SportsFacilityCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SportsFacility> SportsFacilities { get; set; }
    }
}