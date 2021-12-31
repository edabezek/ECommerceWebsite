using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceEntities.Models
{
    public class BaseEntity
    {
        public DateTime CreatingDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActived { get; set; }
    }
}
