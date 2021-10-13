using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
  public class HomeWork : IModel
  {
    public string Label { get; set; }
    public string Matter { get; set; }
    public DateTime Created { get; set; }
    public string By { get; set; }
    public DateTime Return { get; set; }
    public string Content { get; set; }

    public HomeWork()
    {

    }

    public HomeWork(HomeWork homeWork)
    {
      Console.WriteLine("John: " + homeWork.ToString());
      Label = homeWork.Label;
      Matter = homeWork.Matter;
      Created = homeWork.Created;
      By = homeWork.By;
      Return = homeWork.Return;
      Content = homeWork.Content;
    }
    public HomeWork(string label, string matter, DateTime created, string by, DateTime whentoreturn, string content)
    {
      Label = label;
      Matter = matter;
      Created = created;
      By = by;
      Return = whentoreturn;
      Content = content;
    }

    public override string ToString()
    {
      return $"{id} : {Matter} > {Label} : {Return.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"))} : {Content}";
    }
  }
}
