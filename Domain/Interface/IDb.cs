using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDb
    {
        public void ConnectDb();
        public void DisconnectDb();

        public void GetModelItem<T>();
        public void GetModelItem<T>(int id);

        public void CreateModelItem<T>(T item);
        public void DeleteModelItem<T>(int id);
        public void UpdateModelItem<T>(int id, T item);
        
    }
}
