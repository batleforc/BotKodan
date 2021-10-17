using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Model;
using Infra.Database.inDatabase;
using Infra.Database.Model;
using LinqToDB;

namespace Infra.Database
{
    public class InDatabase<T>  : IDb<T> where T : IModel
    {
        public void ConnectDb()
        {
            Console.WriteLine("Database Connected");
            using (var db = new DbConnect())
            {
                try
                {
                    db.CreateTable<HomeWork>();
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void CreateModelItem(T item)
        {
            using (var db = new DbConnect())
            {
                db.Insert(item);
            }
        }

        public void DeleteModelItem(int id)
        {
            Type elementType = typeof(HomeWork);
            if (elementType.Equals(typeof(HomeWork)))
                using (var db = new DbConnect())
                {
                    db.HomeWork
                        .Where(p => p.id == id)
                        .Delete();
                }
        }

        public void DisconnectDb()
        {
            Console.WriteLine("Disconnected");
        }

        public List<T> GetModelItem()
        {
            using (var db = new DbConnect())
            {
                var query = from p in db.HomeWork
                            select p;
                var test = query.ToList();
                foreach(HomeWork homeWork in test)
                {
                    Console.WriteLine(homeWork);
                }
                

                return new List<T>((IEnumerable<T>)query.ToList());
            }
        }

        public T GetModelItem(int id)
        {
            Type elementType = typeof(HomeWork);
            if (elementType.Equals(typeof(HomeWork)))
            {
                using (var db = new DbConnect())
                {
                    var query = from p in db.HomeWork
                                where p.id == id
                                select p;
                    return (T)query.First<IModel>();
                }
            }
            return null;
        }

        public void UpdateModelItem(int id, T item)
        {
            using (var db = new DbConnect())
            {
                db.Update(item);
            }
        }
    }
}
