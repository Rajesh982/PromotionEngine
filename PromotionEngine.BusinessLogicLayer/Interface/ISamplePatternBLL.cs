using PromotionEngine.DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.BusinessLogicLayer.Interface
{
    
    public interface ISamplePatternBLL<T> where T : Entity
    {
        T Select(Object Id);
        List<T> SelectAll();
        List<T> SelectList(KeyValuePair<string, object> columnAndvalue);
        bool Insert(T type);
        bool Update(T type);
        bool Delete(Object Id);
    }
}
