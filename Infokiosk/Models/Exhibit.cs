using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    [PetaPoco.TableName("Exhibits")]
    [PetaPoco.PrimaryKey("ExhibitId")]
    public class Exhibit
    {
        public long ExhibitId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; }
    }
}