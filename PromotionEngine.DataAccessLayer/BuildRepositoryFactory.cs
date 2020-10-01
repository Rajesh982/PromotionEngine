using PromotionEngine.DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.DataAccessLayer
{
   
    public static class BuildRepositoryFactory<T> where T : Entity
    {
        public static IRepository<T> Create()
        {
            return new Repository<T>();
        }

    }
}
