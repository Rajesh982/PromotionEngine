using PromotionEngine.BusinessLogicLayer.Interface;
using PromotionEngine.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.BusinessLogicLayer
{
   
    public class BatchPromotionBLL : PromotionEngineBLL, IBatchPromotionBLL
    {
        public double CalculateTotal(OrderDTO order, List<BatchPromotionDTO> batchPromotionList)
        {
            double total = 0;
            int count = 0;
            var itemCounts = new Dictionary<string, int>();
            var remainingItemCounts = new Dictionary<string, int>();
            var items = new List<ProductDTO>();

            if(order.Items.Any(x=> x.Price == 0))
                throw new ArgumentException("Product price should not be zero");

            foreach (var promo in batchPromotionList)
            {
                count = 0;
                foreach (var item in promo.Codes)
                {
                    itemCounts.Add(item, order.Items.FindAll(p => p.Code == item).Count);
                    count = count == 0 ? order.Items.FindAll(p => p.Code == item).Count : count > order.Items.FindAll(p => p.Code == item).Count ? order.Items.FindAll(p => p.Code == item).Count : count;
                }

                total += promo.DiscountedPrice * count;

                foreach (var item in itemCounts.Keys)
                {
                    remainingItemCounts.Add(item, itemCounts[item] - count);
                }
                itemCounts = new Dictionary<string, int>();
            }
            foreach (var item in remainingItemCounts.Keys)
            {
                total += order.Items.Find(p => p.Code == item).Price * remainingItemCounts[item];
            }
            var distinctProduct = order.Items.Distinct(new ProductComparer());
            foreach (var item in distinctProduct)
            {
                if (!remainingItemCounts.ContainsKey(item.Code))
                    total += order.Items.FindAll(p => p.Code == item.Code).Count * item.Price;
            }
            return total;
        }
    }
}
