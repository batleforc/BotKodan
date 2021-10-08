using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Interface;
namespace Domain.Handler
{
    public class HandleHomeWork
    {
        private IDb<HomeWork> db;
        public HandleHomeWork(IDb<HomeWork> dbAccess)
        {
            db = dbAccess;
        }
        public List<HomeWork> GetHomeWork()
        {
            return db.GetModelItem();
        }

        public HomeWork GetHomeWork(int id)
        {
            return db.GetModelItem(id);
        }

        public Boolean CreateHomeWork(HomeWork homeWork)
        {
            db.CreateModelItem(homeWork);
            return true;
        }

        public Boolean EditHomeWork(int id, HomeWork homeWork)
        {
            db.UpdateModelItem(id, homeWork);
            return true;
        }

        public Boolean DeleteHomeWork(int id)
        {
            db.DeleteModelItem(id);
            return true;
        }
    }
}
