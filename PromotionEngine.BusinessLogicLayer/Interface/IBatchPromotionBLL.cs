using PromotionEngine.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.BusinessLogicLayer.Interface
{
    public interface IBatchPromotionBLL
    {
        double CalculateTotal(OrderDTO order, List<BatchPromotionDTO> promos);
    }
}
