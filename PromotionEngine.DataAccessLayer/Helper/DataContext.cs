using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.DataAccessLayer.Helper
{
   public class DataContext : DbContext
    {
        public DataContext(string connectionString) : base() { }
    }
}
