using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class SportsFacility
    {
        public int Id { get; set; }
        public SportsFacilityCategory Category  { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; }
        //public List<string> Images { get; set; }

        //public SportsFacility()
        //{
        //    Images = new List<string>();
        //}

        ////public SportsFacility(SportsFacility sf, List<Image> images)
        //{
        //    Category = sf.Category;
        //    Name = sf.Name;
        //    Description = sf.Description;
        //    Images = images;
        //}
    }
}