using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [TableName("Prizes")]
    [PrimaryKey("PrizeId")]
    public class Prize
    {
        public long PrizeId { get; set; }
        public string Name { get; set; }
    }
}