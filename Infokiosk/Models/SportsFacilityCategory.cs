using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [TableName("SportsFilityCategory")]
    [PrimaryKey("CategoryId")]
    public class SportsFacilityCategory
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
    }
}