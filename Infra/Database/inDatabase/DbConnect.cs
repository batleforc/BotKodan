using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Database.Model;

namespace Infra.Database.inDatabase
{
    public class DbConnect : LinqToDB.Data.DataConnection
    {
        public DbConnect() : base("MainConfiguration") { }
        public ITable<HomeWorkDb> HomeWork => GetTable<HomeWorkDb>();
    }
}
