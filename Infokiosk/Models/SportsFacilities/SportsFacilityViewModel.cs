using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class SportsFacilityViewModel
    {
        public SportsFacility SportsFacility { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}