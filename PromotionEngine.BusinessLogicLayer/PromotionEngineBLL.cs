using PromotionEngine.BusinessLogicLayer.Interface;
using PromotionEngine.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.BusinessLogicLayer
{
    public class PromotionEngineBLL : IPromotionEngineBLL
    {
        public double CalculateTotal(OrderDTO order, List<PromotionConfigurationDTO> promotionConfiguration)
        {
            double total = 0;
            var items = new List<ProductDTO>();

            if (order.Items.Any(x => x.Price == 0))
                throw new ArgumentException("Product price should not be zero");

            foreach (var item in promotionConfiguration)
            {
                total +=  (order.Items.FindAll(p => p.Code == item.Code).Count / item.Quantity * item.DiscountPrice)
                        + (order.Items.FindAll(p => p.Code == item.Code).Count % item.Quantity * item.UnitPrice);
            }
            IEnumerable<ProductDTO> distProduct = order.Items.Distinct(new ProductComparer());
            foreach (var item in distProduct)
            {
                if (!promotionConfiguration.Any(p => p.Code == item.Code))
                    total += order.Items.FindAll(p => p.Code == item.Code).Count * item.Price;
            }
            return total;
        }

        public double CalculateTotal(OrderDTO order, double discountPercentage)
        {
            double total = 0;
            foreach (var item in order.Items)
            {
                total += item.Price - (item.Price * discountPercentage) / 100;
            }
            return total;
        }
    }
}
