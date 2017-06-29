using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Infokiosk.Models
{
    [TableName("EventCategories")]
    [PrimaryKey("EventCategoryId")]
    public class EventCategory
    {
        public long EventCategoryId { get; set; }
        public string Name { get; set; }
    }
}