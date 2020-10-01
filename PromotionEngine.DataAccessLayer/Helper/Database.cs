using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.DataAccessLayer.Helper
{
    
    internal abstract class Database<T> : IDatabase<T> where T : class
    {
        protected Database(string connectionString)
        {
        }

        public abstract bool Insert(T type);
        public abstract T Select(Object PkId);
        public abstract List<T> SelectAll();
        public abstract List<T> SelectList(KeyValuePair<string, object> columnAndvalue);
        public abstract bool Update(T type, Object PkId = null);
        public abstract bool Delete(Object PkId);
    }
}
