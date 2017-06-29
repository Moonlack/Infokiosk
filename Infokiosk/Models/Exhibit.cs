using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [TableName("Exhibits")]
    [PrimaryKey("Exhibit_Id")]
    [ExplicitColumns]
    public class Exhibit
    {
        [Column] public long ExhibitId { get; set; }
        [Column] public string Category { get; set; }
        [Column] public string Name { get; set; }
        [Column] public string Description { get; set; }
        public List<Image> Images { get; set; }
    }
}