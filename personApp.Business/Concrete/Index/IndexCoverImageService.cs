using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.MongoEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete.Index
{
    public class IndexCoverImageService : IIndexCoverImageService
    {
        private readonly IMongoCollection<IndexCoverImage> _indexCoverImage;

        public IndexCoverImageService(IMongoDbContext mongoDbContext)
        {
            _indexCoverImage = mongoDbContext.GetCollection<IndexCoverImage>();
        }

        public int Add(int IndexId, IFormFile file)
        {
            var coverObject = _indexCoverImage.Find(p => p.IndexId == IndexId).FirstOrDefault();
            if (coverObject != null) return -1;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                var newCoverObject = new IndexCoverImage
                {
                    Id = ObjectId.GenerateNewId(),
                    IndexId = IndexId,
                    Image = memoryStream.ToArray()
                };
                _indexCoverImage.InsertOne(newCoverObject);
            }
            return 1;

        }

        public int Delete(int IndexId)
        {
            var coverObject = _indexCoverImage.Find(p => p.IndexId == IndexId).FirstOrDefault();
            if (coverObject == null) return -1;

            var result = _indexCoverImage.DeleteOne(p => p.IndexId == IndexId);
            if(!result.IsAcknowledged) return -2;
            return 1;
        }

        public byte[] Get(int IndexId)
        {
            var coverObject = _indexCoverImage.Find(p => p.IndexId == IndexId).FirstOrDefault();
            if (coverObject == null) return null;
            return coverObject.Image;
        }

        public int Update(int IndexId, IFormFile file)
        {
            var coverObject = _indexCoverImage.Find(p => p.IndexId == IndexId).FirstOrDefault();
            if (coverObject != null) return -1;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                coverObject.Image = memoryStream.ToArray();

                var result = _indexCoverImage.ReplaceOne(p => p.IndexId == IndexId, coverObject);
                if (!result.IsAcknowledged) return -2;
                return 1;
            }
        }
    }
}
