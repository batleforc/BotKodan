using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using Domain.Model;

namespace Infra.Database.Model
{
    [Table(Name = "HomeWork")]
    public class HomeWorkDb : HomeWork
    {
        [PrimaryKey,Identity]
        public new int id { get; set; }

        [Column]
        public new string Label { get; set; }
        [Column]
        public new string Matter { get; set; }
        [Column]
        public new DateTime Created { get; set; }
        [Column]
        public new string By { get; set; }
        [Column]
        public new DateTime Return { get; set; }
        [Column]
        public new string Content { get; set; }

        public HomeWorkDb() { }
        public HomeWorkDb(HomeWork homeWork)
        {
            id = homeWork.id;
            Label = homeWork.Label;
            Matter = homeWork.Matter;
            Created = homeWork.Created;
            By = homeWork.By;
            Return = homeWork.Return;
            Content = homeWork.Content;
        }

        public HomeWork toHomeWork()
        {
            return new HomeWork()
            {
                id = this.id,
                Label = this.Label,
                Matter = this.Matter,
                Created = this.Created,
                By = this.By,
                Return = this.Return,
                Content = this.Content
            };
        }
    }
}
