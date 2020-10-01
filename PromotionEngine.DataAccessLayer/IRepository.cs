using PromotionEngine.DomainEntity;
using System;
using System.Collections.Generic;

namespace PromotionEngine.DataAccessLayer
{
    public interface IRepository<T> where T : Entity
    {
        T Select(Object PkId);
        List<T> SelectAll();
        List<T> SelectList(KeyValuePair<string, object> columnAndvalue);
        bool Insert(T type);
        bool Update(T type);
        bool Delete(Object PkId);
    }
}
