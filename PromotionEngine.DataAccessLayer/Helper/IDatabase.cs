using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.DataAccessLayer.Helper
{   
    public interface IDatabase<T> where T : class
    {
        T Select(Object PkId);
        List<T> SelectAll();
        List<T> SelectList(KeyValuePair<string, object> columnAndvalue);
        bool Insert(T type);
        bool Update(T type, Object PkId = null);
        bool Delete(Object PkId);
    }

}
