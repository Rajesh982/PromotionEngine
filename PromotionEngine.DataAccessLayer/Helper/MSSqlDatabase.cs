using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.DataAccessLayer.Helper
{
   
    internal class MSSqlDatabase<T> : Database<T> where T : class
    {
        private readonly DataContext _dbContext;
        private readonly DbSet<T> table;
       

        public MSSqlDatabase(string connectionString) : base(connectionString)
        {
            _dbContext = new DataContext(connectionString);
            table = _dbContext.Set<T>();
        }
      
        public override bool Insert(T type)
        {
            table.Add(type);
            return _dbContext.SaveChanges() > 0;
        }

        public override T Select(Object pkId)
        {
            return table.Find(pkId);
        }

        public override List<T> SelectAll()
        {
            return table.ToList();
        }

        public override List<T> SelectList(KeyValuePair<string, object> columnAndvalue)
        {
            string column = columnAndvalue.Key;
            object value = columnAndvalue.Value;
            return table.ToList();
        }

        public override bool Update(T type, Object PkId = null)
        {
            table.Attach(type);
            return _dbContext.SaveChanges() > 0;
        }

        public override bool Delete(Object PkId)
        {
            table.Remove(table.Find(PkId));
            return _dbContext.SaveChanges() > 0;
        }
        
    }

}
