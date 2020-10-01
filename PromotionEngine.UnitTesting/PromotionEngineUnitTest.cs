using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.BusinessLogicLayer;
using PromotionEngine.DTO;

namespace PromotionEngine.UnitTesting
{
    [TestClass]
    public class PromotionEngineUnitTest
    {
        [TestMethod]
        public void ScenarioA_ValidData_ReturnValidNumber()
        {
            var promotionConfig = new List<PromotionConfigurationDTO>();
            promotionConfig.Add(new PromotionConfigurationDTO() { Code = "A", Quantity = 3, UnitPrice = 50, DiscountPrice = 130 });
            promotionConfig.Add(new PromotionConfigurationDTO() { Code = "B", Quantity = 2, UnitPrice = 30, DiscountPrice = 50 });

            var orderSA = new OrderDTO() { Id = 123, OrderDate = DateTime.Today, Status = OrderStatusDTO.Pending, Items = new List<ProductDTO>() };
            orderSA.Items.Add(new ProductDTO("A") { Id = 1, Code = "A", Name = "A", SKUcode = "A1", Price = 50 });
            orderSA.Items.Add(new ProductDTO("B") { Id = 6, Code = "B", Name = "B", SKUcode = "B3", Price = 30 });
            orderSA.Items.Add(new ProductDTO("C") { Id = 7, Code = "C", Name = "C", SKUcode = "C1", Price = 20 });

            var expectedValue = 100;
            var actualValue = new BatchPromotionBLL().CalculateTotal(orderSA, promotionConfig);

            Assert.IsNotNull(actualValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [ExpectedException(typeof(ArgumentException), "Product price should not be zero or null")]
        [TestMethod]
        public void ScenarioA_InvalidData_ThrowException()
        {
            var promotionConfig = new List<PromotionConfigurationDTO>();
            promotionConfig.Add(new PromotionConfigurationDTO() { Code = "A", Quantity = 3, UnitPrice = 0, DiscountPrice = 0 });
            promotionConfig.Add(new PromotionConfigurationDTO() { Code = "B", Quantity = 2, UnitPrice = 0, DiscountPrice = 0 });

            var orderSA = new OrderDTO() { Id = 123, OrderDate = DateTime.Today, Status = OrderStatusDTO.Pending, Items = new List<ProductDTO>() };
            orderSA.Items.Add(new ProductDTO("A") { Id = 1, Code = "A", Name = "A", SKUcode = "A1", Price = 0 });
            orderSA.Items.Add(new ProductDTO("B") { Id = 6, Code = "B", Name = "B", SKUcode = "B3", Price = 0 });
            orderSA.Items.Add(new ProductDTO("C") { Id = 7, Code = "C", Name = "C", SKUcode = "C1", Price = 0 });
          
            new BatchPromotionBLL().CalculateTotal(orderSA, promotionConfig);
            Assert.Fail();           
        }

        [TestMethod]
        public void ScenarioB_ValidData_ReturnValidNumber()
        {
            var promotionConfig = new List<PromotionConfigurationDTO>();
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

            var expectedValue = 370;
            var actualValue = new BatchPromotionBLL().CalculateTotal(orderSB, promotionConfig);

            Assert.IsNotNull(actualValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [ExpectedException(typeof(ArgumentException), "Product price should not be zero or null")]
        [TestMethod]
        public void ScenarioB_InvalidData_ThrowException()
        {
            var promotionConfig = new List<PromotionConfigurationDTO>();
            promotionConfig.Add(new PromotionConfigurationDTO() { Code = "A", Quantity = 3, UnitPrice = 50, DiscountPrice = 130 });
            promotionConfig.Add(new PromotionConfigurationDTO() { Code = "B", Quantity = 2, UnitPrice = 30, DiscountPrice = 45 });

            var orderSB = new OrderDTO() { Id = 123, OrderDate = DateTime.Today, Status = OrderStatusDTO.Pending, Items = new List<ProductDTO>() };
            orderSB.Items.Add(new ProductDTO("A") { Id = 1, Code = "A", Name = "A", SKUcode = "A1", Price = 0 });
            orderSB.Items.Add(new ProductDTO("A") { Id = 2, Code = "A", Name = "A", SKUcode = "A2", Price = 0 });
            orderSB.Items.Add(new ProductDTO("A") { Id = 3, Code = "A", Name = "A", SKUcode = "A3", Price = 0 });
            orderSB.Items.Add(new ProductDTO("A") { Id = 4, Code = "A", Name = "A", SKUcode = "A4", Price = 0 });
            orderSB.Items.Add(new ProductDTO("A") { Id = 5, Code = "A", Name = "A", SKUcode = "A5", Price = 0 });
            orderSB.Items.Add(new ProductDTO("B") { Id = 6, Code = "B", Name = "B", SKUcode = "B1", Price = 30 });
            orderSB.Items.Add(new ProductDTO("B") { Id = 7, Code = "B", Name = "B", SKUcode = "B2", Price = 30 });
            orderSB.Items.Add(new ProductDTO("B") { Id = 8, Code = "B", Name = "B", SKUcode = "B3", Price = 30 });
            orderSB.Items.Add(new ProductDTO("B") { Id = 9, Code = "B", Name = "B", SKUcode = "B4", Price = 30 });
            orderSB.Items.Add(new ProductDTO("B") { Id = 10, Code = "B", Name = "B", SKUcode = "B5", Price = 30 });
            orderSB.Items.Add(new ProductDTO("C") { Id = 11, Code = "C", Name = "C", SKUcode = "C1", Price = 20 });

            new BatchPromotionBLL().CalculateTotal(orderSB, promotionConfig);
            Assert.Fail();
        }

        [TestMethod]
        public void ScenarioC_ValidData_ReturnValidNumber()
        {
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

            var expectedValue = 330;
            var actualValue = new BatchPromotionBLL().CalculateTotal(orderSC, batchPromotionList);           

            Assert.IsNotNull(actualValue);
            Assert.AreEqual(expectedValue, actualValue);

        }

        [ExpectedException(typeof(ArgumentException), "Product price should not be zero or null")]
        [TestMethod]
        public void ScenarioC_InvalidData_ThrowException()
        {
            var batchPromotionList = new List<BatchPromotionDTO>();
            batchPromotionList.Add(new BatchPromotionDTO() { Codes = new List<string>() { "C", "D" }, DiscountedPrice = 30 });

            var orderSC = new OrderDTO() { Id = 123, OrderDate = DateTime.Today, Status = OrderStatusDTO.Pending, Items = new List<ProductDTO>() };
            orderSC.Items.Add(new ProductDTO("A") { Id = 1, Code = "A", Name = "A", SKUcode = "A1", Price = 0 });
            orderSC.Items.Add(new ProductDTO("A") { Id = 2, Code = "A", Name = "A", SKUcode = "A2", Price = 0 });
            orderSC.Items.Add(new ProductDTO("A") { Id = 3, Code = "A", Name = "A", SKUcode = "A3", Price = 0 });
            orderSC.Items.Add(new ProductDTO("B") { Id = 4, Code = "B", Name = "B", SKUcode = "B1", Price = 30 });
            orderSC.Items.Add(new ProductDTO("B") { Id = 5, Code = "B", Name = "B", SKUcode = "B2", Price = 30 });
            orderSC.Items.Add(new ProductDTO("B") { Id = 6, Code = "B", Name = "B", SKUcode = "B3", Price = 0 });
            orderSC.Items.Add(new ProductDTO("B") { Id = 7, Code = "B", Name = "B", SKUcode = "B4", Price = 30 });
            orderSC.Items.Add(new ProductDTO("B") { Id = 8, Code = "B", Name = "B", SKUcode = "B5", Price = 0 });
            orderSC.Items.Add(new ProductDTO("C") { Id = 9, Code = "C", Name = "C", SKUcode = "C1", Price = 20 });
            orderSC.Items.Add(new ProductDTO("D") { Id = 10, Code = "D", Name = "D", SKUcode = "D1", Price = 15 });

            new BatchPromotionBLL().CalculateTotal(orderSC, batchPromotionList);
            Assert.Fail();
        }

        [TestMethod]
        public void CalculateTotal_ValidData_ReturnValidNumber()
        {
            var orderSC = new OrderDTO() { Id = 123, OrderDate = DateTime.Today, Status = OrderStatusDTO.Pending, Items = new List<ProductDTO>() };
            orderSC.Items.Add(new ProductDTO("A") { Id = 1, Code = "A", Name = "A", SKUcode = "A1", Price = 50 });
            orderSC.Items.Add(new ProductDTO("A") { Id = 2, Code = "A", Name = "A", SKUcode = "A2", Price = 50 });
            orderSC.Items.Add(new ProductDTO("A") { Id = 3, Code = "A", Name = "A", SKUcode = "A3", Price = 50 });           
            
            var actualValue = new BatchPromotionBLL().CalculateTotal(orderSC, 20 );

            Assert.IsNotNull(actualValue);
        }

        [ExpectedException(typeof(ArgumentException), "Discount Percentage should not be zero")]
        [TestMethod]
        public void CalculateTotal_InValidData_ThrowException()
        {
            var orderSC = new OrderDTO() { Id = 123, OrderDate = DateTime.Today, Status = OrderStatusDTO.Pending, Items = new List<ProductDTO>() };
            orderSC.Items.Add(new ProductDTO("A") { Id = 1, Code = "A", Name = "A", SKUcode = "A1", Price = 50 });
            orderSC.Items.Add(new ProductDTO("A") { Id = 2, Code = "A", Name = "A", SKUcode = "A2", Price = 50 });
            orderSC.Items.Add(new ProductDTO("A") { Id = 3, Code = "A", Name = "A", SKUcode = "A3", Price = 50 });

            new BatchPromotionBLL().CalculateTotal(orderSC, 0);
            Assert.Fail();
        }

    }
}
