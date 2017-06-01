using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class AdminExhibitsViewModel
    {
        public List<Exhibit> Exhibits { get; set; }
        public Exhibit Exhibit { get; set; }        
    }
}