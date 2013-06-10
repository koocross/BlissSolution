using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using Forum.CQRS.Core;
using Newtonsoft.Json;

namespace Forum.Domain.Repository
{
    public interface IRepository<T> where T : AggregateRoot, new()
    {
        T GetByAggregateId(Guid id);

        void Save(T aggreate);
    }

    public class Repository<T> : IRepository<T> where T : AggregateRoot, new()
    {
        //private readonly IList<T> innerList = new List<T>();
        //private readonly object syncRoot = new object();
        //private readonly string fileName;

        //public Repository() {
            //fileName = ConfigurationManager.AppSettings["fileName"];
            //var records = File.ReadAllLines(fileName, Encoding.UTF8);
            //foreach (var record in records) {
            //    innerList.Add(JsonConvert.DeserializeObject<T>(record));
            //}
        //}

        public T GetByAggregateId(Guid id) {
            //return innerList.FirstOrDefault(p => p.AggregateId == id);
            throw new NotImplementedException();
        }

        public void Save(T aggreate) {
            //if (Equals(aggreate, default(T)))
            //    return;

            //lock (syncRoot) {
            //    var item = innerList.FirstOrDefault(p => p.AggregateId == aggreate.AggregateId);
            //    if (Equals(item, default(T)))
            //        innerList.Add(aggreate);
            //    else {
            //        int index = innerList.IndexOf(item);
            //        innerList[index] = aggreate;
            //    }

            //    var result = innerList.Select(element => JsonConvert.SerializeObject(element)).ToArray();
            //    File.WriteAllLines(fileName, result, Encoding.UTF8);
            //}
            throw new NotImplementedException();
        }
    }
}
