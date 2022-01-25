using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Context
{
    public interface IMongoDbContext
    {
        /// <summary>
        /// collectiona erişmek için kullanılır.
        /// </summary>
        
        IMongoCollection<T> GetCollection<T>();
        /// <summary>
        /// veritabanına erişmek için kullanılır.
        /// </summary>
        /// <returns></returns>
        IMongoDatabase GetDatabase();
    }
}
