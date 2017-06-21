using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    [PetaPoco.TableName("Images")]
    [PetaPoco.PrimaryKey("ImageId")]
    public class Image
    {
        public long Id { get; set; }
        public string Filename { get; set; }

        public long  AthleteId { get; set; }
        public long ExhibitId { get; set; }
        public long EventId { get; set; }
        public long KindOfSportId { get; set; }
        public long SportsFacilityId { get; set; }
    }
}