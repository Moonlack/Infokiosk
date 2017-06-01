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
    }
}