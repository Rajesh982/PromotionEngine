using PromotionEngine.DataAccessLayer.Helper;
using PromotionEngine.DomainEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace PromotionEngine.DataAccessLayer
{
    internal class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IDatabase<T> _db;
        public Repository()
        {
            this._db = DatabaseFactory<T>.Create(ConfigurationManager.ConnectionStrings["DatabaseEntities"].ConnectionString);
        }

        bool IRepository<T>.Insert(T type)
        {
            return this._db.Insert(type);
        }

        T IRepository<T>.Select(object PkId)
        {
            return this._db.Select(PkId);
        }

        List<T> IRepository<T>.SelectAll()
        {
            return this._db.SelectAll();
        }

        List<T> IRepository<T>.SelectList(KeyValuePair<string, object> columnAndvalue)
        {
            return this._db.SelectList(columnAndvalue);
        }

        bool IRepository<T>.Update(T type)
        {
            return this._db.Update(type);
        }

        bool IRepository<T>.Delete(object PkId)
        {
            return this._db.Delete(PkId);
        }
    }
}
