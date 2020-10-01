using System;
using System.Collections.Generic;
using System.Linq;
using PromotionEngine.BusinessLogicLayer;
using PromotionEngine.DTO;
using System.Threading.Tasks;

namespace PromotionEngine.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Scenario A - Expected output : 100

            var promotionConfig = new List<PromotionConfigurationDTO>();
            promotionConfig.Add(new PromotionConfigurationDTO() { Code = "A", Quantity = 3, UnitPrice = 50, DiscountPrice = 130 });
            promotionConfig.Add(new PromotionConfigurationDTO() { Code = "B", Quantity = 2, UnitPrice = 30, DiscountPrice = 50 });

            var orderSA = new OrderDTO() { Id = 123, OrderDate = DateTime.Today, Status = OrderStatusDTO.Pending, Items = new List<ProductDTO>() };
            orderSA.Items.Add(new ProductDTO("A") { Id = 1, Code = "A", Name = "A", SKUcode = "A1", Price = 50 });
            orderSA.Items.Add(new ProductDTO("B") { Id = 6, Code = "B", Name = "B", SKUcode = "B3", Price = 30 });
            orderSA.Items.Add(new ProductDTO("C") { Id = 7, Code = "C", Name = "C", SKUcode = "C1", Price = 20 });

            var resultSA = new BatchPromotionBLL().CalculateTotal(orderSA, promotionConfig);

            Console.WriteLine("Scenario A - Expected output : " + resultSA);
            #endregion

            #region Scenario B - Expected output : 370 

            promotionConfig = new List<PromotionConfigurationDTO>();
            promotionConfig.Add(new PromotionConfigurationDTO() { Code = "A", Quantity = 3, UnitPrice = 50, DiscountPrice = 130 });
            promotionConfig.Add(new PromotionConfigurationDTO() { Code = "B", Quantity = 2, UnitPrice = 30, DiscountPrice = 45 });

            var orderSB = new OrderDTO() { Id = 123, OrderDate = DateTime.Today, Status = OrderStatusDTO.Pending, Items = new List<ProductDTO>() };
            orderSB.Items.Add(new ProductDTO("A") { Id = 1, Code = "A", Name = "A", SKUcode = "A1", Price = 50 });
            orderSB.Items.Add(new ProductDTO("A") { Id = 2, Code = "A", Name = "A", SKUcode = "A2", Price = 50 });
            orderSB.Items.Add(new ProductDTO("A") { Id = 3, Code = "A", Name = "A", SKUcode = "A3", Price = 50 });
            orderSB.Items.Add(new ProductDTO("A") { Id = 4, Code = "A", Name = "A", SKUcode = "A4", Price = 50 });
            orderSB.Items.Add(new ProductDTO("A") { Id = 5, Code = "A", Name = "A", SKUcode = "A5", Price = 50 });
            orderSB.Items.Add(new ProductDTO("B") { Id = 6, Code = "B", Name = "B", SKUcode = "B1", Price = 30 });
            orderSB.Items.Add(new ProductDTO("B") { Id = 7, Code = "B", Name = "B", SKUcode = "B2", Price = 30 });
            orderSB.Items.Add(new ProductDTO("B") { Id = 8, Code = "B", Name = "B", SKUcode = "B3", Price = 30 });
            orderSB.Items.Add(new ProductDTO("B") { Id = 9, Code = "B", Name = "B", SKUcode = "B4", Price = 30 });
            orderSB.Items.Add(new ProductDTO("B") { Id = 10, Code = "B", Name = "B", SKUcode = "B5", Price = 30 });
            orderSB.Items.Add(new ProductDTO("C") { Id = 11, Code = "C", Name = "C", SKUcode = "C1", Price = 20 });

            var resultSB = new BatchPromotionBLL().CalculateTotal(orderSB, promotionConfig);
            Console.WriteLine("Scenario B - Expected output : " + resultSB);
            #endregion

            #region Scenario C - Expected output : 330 

            var batchPromotionList = new List<BatchPromotionDTO>();
            batchPromotionList.Add(new BatchPromotionDTO() { Codes = new List<string>() { "C", "D" }, DiscountedPrice = 30 });

            var orderSC = new OrderDTO() { Id = 123, OrderDate = DateTime.Today, Status = OrderStatusDTO.Pending, Items = new List<ProductDTO>() };
            orderSC.Items.Add(new ProductDTO("A") { Id = 1, Code = "A", Name = "A", SKUcode = "A1", Price = 50 });
            orderSC.Items.Add(new ProductDTO("A") { Id = 2, Code = "A", Name = "A", SKUcode = "A2", Price = 50 });
            orderSC.Items.Add(new ProductDTO("A") { Id = 3, Code = "A", Name = "A", SKUcode = "A3", Price = 50 });
            orderSC.Items.Add(new ProductDTO("B") { Id = 4, Code = "B", Name = "B", SKUcode = "B1", Price = 30 });
            orderSC.Items.Add(new ProductDTO("B") { Id = 5, Code = "B", Name = "B", SKUcode = "B2", Price = 30 });
            orderSC.Items.Add(new ProductDTO("B") { Id = 6, Code = "B", Name = "B", SKUcode = "B3", Price = 30 });
            orderSC.Items.Add(new ProductDTO("B") { Id = 7, Code = "B", Name = "B", SKUcode = "B4", Price = 30 });
            orderSC.Items.Add(new ProductDTO("B") { Id = 8, Code = "B", Name = "B", SKUcode = "B5", Price = 30 });
            orderSC.Items.Add(new ProductDTO("C") { Id = 9, Code = "C", Name = "C", SKUcode = "C1", Price = 20 });
            orderSC.Items.Add(new ProductDTO("D") { Id = 10, Code = "D", Name = "D", SKUcode = "D1", Price = 15 });

            var resultSC = new BatchPromotionBLL().CalculateTotal(orderSC, batchPromotionList);
            Console.WriteLine("Scenario C - Expected output : " + resultSC);
            #endregion

            Console.ReadLine();
        }
    }
}
