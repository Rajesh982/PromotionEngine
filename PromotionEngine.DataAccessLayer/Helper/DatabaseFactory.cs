using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Resolution;
using System.Configuration;

namespace PromotionEngine.DataAccessLayer.Helper
{
  
    public static class DatabaseFactory<T> where T : class
    {
        private static DatabaseType _databaseType;
        private static IUnityContainer _unityContainer = new UnityContainer();
        private static string _connectionString;

        static DatabaseFactory()
        {
            Register();
            LoadDefault();
        }

        private static void Register()
        {
            _unityContainer.RegisterType<IDatabase<T>, MSSqlDatabase<T>>(typeof(MSSqlDatabase<T>).Name);
           //Register for Oracle & MySql            
        }

        private static IDatabase<T> Resolve(string type)
        {
            return _unityContainer.Resolve<IDatabase<T>>(type, new ResolverOverride[] { new ParameterOverride("connectionString", _connectionString) });
        }

        private static void LoadDefault()
        {
            _databaseType = (DatabaseType)Int32.Parse(ConfigurationManager.AppSettings["DBProvider"].ToString());
        }

        public static void ConfigureDefault(DatabaseType dbtype)
        {
            _databaseType = dbtype;
        }

        public static IDatabase<T> Create(String connectionString)
        {
            _connectionString = connectionString;
            switch (_databaseType)
            {
                case DatabaseType.MSSql: return Resolve(typeof(MSSqlDatabase<T>).Name);               
                // Add more database, when it's required
                default: return null;
            }
        }

    }
}
