﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [TableName("KindsOfSports")]
    [PrimaryKey("KindOfSportId")]
    [ExplicitColumns]
    public class KindOfSport
    {
        [Column] public long KindOfSportId { get; set; }
        [Column] public string Name { get; set; }
        [Column] public string Description { get; set; }
        public List<Image> Images { get; set; }
    }
}