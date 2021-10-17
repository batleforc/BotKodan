using LinqToDB.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.inDatabase
{
    public class ConnectionSettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "MainConfiguration";

        public string DefaultDataProvider => Environment.GetEnvironmentVariable("DB_PROVIDER");

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "MainConfiguration",
                        ProviderName = Environment.GetEnvironmentVariable("DB_PROVIDER"),
                        ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTIONSTRING")
                    };
            }
        }
    }
}
