using System;
using System.Collections.Generic;

namespace PromotionEngine.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public List<ProductDTO> Items { get; set; }
        public double Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatusDTO Status { get; set; }
    }
}
