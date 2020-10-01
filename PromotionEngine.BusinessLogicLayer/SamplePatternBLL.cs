using PromotionEngine.BusinessLogicLayer.Interface;
using PromotionEngine.DataAccessLayer;
using PromotionEngine.DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.BusinessLogicLayer
{    
    public class SamplePatternBLL<T> : ISamplePatternBLL<T> where T : Entity
    {
        private readonly IRepository<T> _repository;

        public SamplePatternBLL()
        {
            this._repository = BuildRepositoryFactory<T>.Create();
        }

        public virtual bool Insert(T type)
        {
            return this._repository.Insert(type);
        }

        public virtual T Select(object Id)
        {
            return this._repository.Select(Id);
        }

        public virtual List<T> SelectAll()
        {
            return this._repository.SelectAll();
        }

        public virtual List<T> SelectList(KeyValuePair<string, object> columnAndvalue)
        {
            return this._repository.SelectList(columnAndvalue);
        }

        public virtual bool Update(T type)
        {
            return this._repository.Update(type);
        }

        public virtual bool Delete(object Id)
        {
            return this._repository.Delete(Id);
        }
    }
}
