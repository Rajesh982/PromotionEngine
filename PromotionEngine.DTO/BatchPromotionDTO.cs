using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.DTO
{
  public  class BatchPromotionDTO
    {
        public List<string> Codes { get; set; }
        public double DiscountedPrice { get; set; }
    }
}
