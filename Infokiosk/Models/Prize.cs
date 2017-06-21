using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    [PetaPoco.TableName("Prizes")]
    [PetaPoco.PrimaryKey("PrizeId")]
    public class Prize
    {
        public long PrizeId { get; set; }
        public string Name { get; set; }
    }
}