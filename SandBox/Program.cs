using System;
using Infra.Database;
using Domain.Model;
using Domain.Handler;
using Domain.Interface;
using Infra.Database.inDatabase;
using LinqToDB.Data;
using LinqToDB.Configuration;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            DataConnection.DefaultSettings = new ConnectionSettings();
            IDb<HomeWork> _database;
            ConnectionSettings connect = new ConnectionSettings();
            Console.WriteLine(connect.DefaultDataProvider);
            var truc = connect.ConnectionStrings.GetEnumerator();
            if (truc.MoveNext())
            {
                IConnectionStringSettings connectString = truc.Current;
                Console.WriteLine(connectString);

            }
            else
            {
                Console.WriteLine("NO DATA");
            }

            
            _database = new InDatabase<HomeWork>();
            _database.ConnectDb();
            HandleHomeWork _handler = new HandleHomeWork(_database);
            _handler.GetHomeWork();

        }
    }
}
