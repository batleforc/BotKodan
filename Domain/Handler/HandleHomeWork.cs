using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
namespace Domain.Handler
{
    public class HandleHomeWork
    {
        public List<HomeWork> GetHomeWork()
        {
            return new List<HomeWork>();
        }

        public HomeWork GetHomeWork(int id)
        {
            return new HomeWork();
        }

        public Boolean CreateHomeWork(HomeWork homeWork)
        {
            return true;
        }

        public Boolean EditHomeWork(int id, HomeWork homeWork)
        {
            return true;
        }

        public Boolean DeleteHomeWork(int id)
        {
            return true;
        }
    }
}
