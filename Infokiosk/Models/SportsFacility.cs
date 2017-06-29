using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [TableName("SportsFacilities")]
    [PrimaryKey("SportsFacilityId")]
    public class SportsFacility
    {
        [Column] public long SportsFacilityId { get; set; }
        public SportsFacilityCategory Category  { get; set; }
        [Column] public int CategoryId { get; set; }
        [Column] public string Name { get; set; }
        [Column] public string Description { get; set; }
        public List<Image> Images { get; set; }
    }
}