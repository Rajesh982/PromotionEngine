using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.DomainEntity
{
    public abstract class Entity
    {
        public Object PkId { get; set; }       
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
