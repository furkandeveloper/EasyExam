using Entities.Models;
using Manager.Configuration;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Context
{
    public class EasyExamContext : DbContext, IEasyExamContext
    {
        protected readonly IMongoDatabase _database = null;
        public EasyExamContext(MongoSetting mongoSettings)
        {
            var client = new MongoClient(mongoSettings.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(mongoSettings.Database);
        }

        public IMongoCollection<Exam> Exams
            => Database.GetCollection<Exam>(nameof(Exams));

        public new IMongoDatabase Database
        {
            get
            {
                return _database;
            }
        }

        public IMongoCollection<T> Set<T>(string collection = null) 
            => Database.GetCollection<T>(collection ?? typeof(T).Name);
    }
}
