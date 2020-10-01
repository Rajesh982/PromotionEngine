using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.DTO
{
    
    public class ProductDTO : IEquatable<ProductDTO>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string SKUcode { get; set; }
        public double Price { get; set; }
        public ProductDTO(string name)
        {
            this.Name = name;
        }

        public bool Equals(ProductDTO other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return Code.Equals(other.Code);
        }

    }

    public class ProductComparer : IEqualityComparer<ProductDTO>
    {
        public bool Equals(ProductDTO a, ProductDTO b)
        {
            if (Object.ReferenceEquals(a, null) || Object.ReferenceEquals(b, null)) return false;
            if (Object.ReferenceEquals(a, b)) return true;          
          
            return (a.Code == b.Code);
        }

        public int GetHashCode(ProductDTO productDto)
        {
            if (Object.ReferenceEquals(productDto, null)) return 0;            
            int hashProductName = productDto.Code == null ? 0 : productDto.Code.GetHashCode();           
            int hashProductCode = productDto.Code.GetHashCode();            
            return hashProductName ^ hashProductCode;
        }
    }
}
