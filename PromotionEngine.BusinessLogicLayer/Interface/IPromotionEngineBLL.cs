using PromotionEngine.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.BusinessLogicLayer.Interface
{
   public interface IPromotionEngineBLL
    {
        double CalculateTotal(OrderDTO order, List<PromotionConfigurationDTO> promos);
        double CalculateTotal(OrderDTO order, double discountPercentage);
    }
}
