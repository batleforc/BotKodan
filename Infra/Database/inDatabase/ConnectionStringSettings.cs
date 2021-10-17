using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Configuration;

namespace Infra.Database.inDatabase
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }

        public string Name { get; set; }

        public string ProviderName { get; set; }

        public bool IsGlobal => false;
    }
}
