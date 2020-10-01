using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.DTO
{
  public class  PromotionConfigurationDTO
        {
        public string Code { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double DiscountPrice { get; set; }
    }

}
