using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Model;
namespace Infra.Database
{
    class InMemory<T> : IDb<T> where T:IModel
    {
        private static List<T> listItem;
        
        public void ConnectDb()
        {
            listItem = new List<T>();
        }

        public void CreateModelItem(T item)
        {
            listItem.Add(item);
        }

        public void DeleteModelItem(int id)
        {
            listItem.FindIndex(item => item.id == id);
        }

        public void DisconnectDb()
        {
            throw new NotImplementedException();
        }

        public void GetModelItem()
        {
            throw new NotImplementedException();
        }

        public void GetModelItem(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateModelItem(int id, T item)
        {
            throw new NotImplementedException();
        }
    }
}
