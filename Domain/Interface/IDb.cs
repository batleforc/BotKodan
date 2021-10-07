using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDb<T>
    {
        public void ConnectDb();
        public void DisconnectDb();

        public List<T> GetModelItem();
        public T GetModelItem(int id);

        public void CreateModelItem(T item);
        public void DeleteModelItem(int id);
        public void UpdateModelItem(int id, T item);
        
    }
}
