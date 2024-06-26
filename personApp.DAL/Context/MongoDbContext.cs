﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using personApp.DAL.MongoEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Context
{
    
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _mongoDB;

        public MongoDbContext(IOptions<MongoOptions> mongoOptions)
        {
            var mongoClient = new MongoClient("mongodb+srv://personadmin:ON29pokvHfVWxMli@cluster0.pwj4pql.mongodb.net/?retryWrites=true&w=majority");
            _mongoDB = mongoClient.GetDatabase(mongoOptions.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _mongoDB.GetCollection<T>(typeof(T).Name);
        }

        public IMongoDatabase GetDatabase()
        {
            return _mongoDB;
        }
    }
}
