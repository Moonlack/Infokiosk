using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    [PetaPoco.TableName("EventCategories")]
    [PetaPoco.PrimaryKey("EventCategoryId")]
    public class EventCategory
    {
        public long EventCategoryId { get; set; }
        public string Name { get; set; }
    }
}