using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Model;
namespace Infra.Database
{
  public class InMemory<T> : IDb<T> where T : IModel
  {
    private static List<T> listItem;

    public void ConnectDb()
    {
      listItem = new List<T>();
    }

    public void CreateModelItem(T item)
    {
      item.id = listItem.Count > 0 ? listItem.Last<T>().id + 1 : 0;
      listItem.Add(item);
    }

    public void DeleteModelItem(int id)
    {
      listItem.RemoveAt(listItem.FindIndex(item => item.id == id));
    }

    public void DisconnectDb()
    {
      listItem = null;
    }

    public List<T> GetModelItem()
    {
      return listItem;
    }

    public T GetModelItem(int id)
    {
      return listItem.Find(item => item.id == id);
    }

    public void UpdateModelItem(int id, T item)
    {
      listItem[listItem.FindIndex(item => item.id == id)] = item;
    }
  }
}
