using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [TableName("Images")]
    [PrimaryKey("ImageId")]
    [ExplicitColumns]
    public class Image
    {
        [Column] public int ImageId { get; set; }
        [Column] public string Filename { get; set; }

        public int AthleteId { get; set; }
        public int ExhibitId { get; set; }
        public int EventId { get; set; }
        public int KindOfSportId { get; set; }
        public int SportsFacilityId { get; set; }
    }
}