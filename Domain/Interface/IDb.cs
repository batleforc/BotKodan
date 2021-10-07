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

        public void GetModelItem();
        public void GetModelItem(int id);

        public void CreateModelItem(T item);
        public void DeleteModelItem(int id);
        public void UpdateModelItem(int id, T item);
        
    }
}
