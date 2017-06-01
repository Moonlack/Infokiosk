using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class SportsFacilitiesViewModel
    {
        public List<string> CategoriesList { get; set; }
        public List<SportsFacility> SportsFacilities { get; set; }
    }
}