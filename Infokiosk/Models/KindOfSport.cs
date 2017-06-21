using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    [PetaPoco.TableName("KindsOfSports")]
    [PetaPoco.PrimaryKey("KindOfSportId")]
    public class KindOfSport
    {
        public long KindOfSportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; }
    }
}