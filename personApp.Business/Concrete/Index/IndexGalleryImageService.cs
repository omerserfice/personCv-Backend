using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using personApp.Business.Abstract.Index;
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
    public class IndexGalleryImageService : IIndexGalleryImageService
    {
        private readonly IMongoCollection<IndexGalleryImage> _indexGalleryImage;

        public IndexGalleryImageService(IMongoDbContext mongoDbContext)
        {
            _indexGalleryImage = mongoDbContext.GetCollection<IndexGalleryImage>(); 
        }
        public int Add(int IndexId, IFormFile file)
        {
            var galleryImage = _indexGalleryImage.Find(x => x.IndexId == IndexId).FirstOrDefault();
            using (var memoryStream = new MemoryStream()) 
            {
                file.CopyTo(memoryStream);
                var newGalleryImage = new IndexGalleryImage
                {
                    Id =ObjectId.GenerateNewId(),
                    IndexId = IndexId,
                    Image = memoryStream.ToArray()

                };
                _indexGalleryImage.InsertOne(newGalleryImage);
            }
            return 1;
        }

        public int Delete(string objectId)
        {
            var galleryImage = _indexGalleryImage.Find(p => p.Id == ObjectId.Parse(objectId)).FirstOrDefault();
            if (galleryImage == null) return -1; 
            var result = _indexGalleryImage.DeleteOne(p => p.Id == ObjectId.Parse(objectId));
            if (!result.IsAcknowledged) return -2;
            return 1;

        }

        public byte[] Get(string objectId)
        {
            var galleryImage = _indexGalleryImage.Find(p => p.Id == ObjectId.Parse(objectId)).FirstOrDefault();
            if (galleryImage == null) return null;

            return galleryImage.Image;
        }

        public IEnumerable<string> Get(int IndexId)
        {
            var galleryImageList = _indexGalleryImage.Find(p => p.IndexId == IndexId).ToList();
            if (galleryImageList.Count == 0) return null;

            var list = new List<string>();
            foreach (var image in galleryImageList)
            {
                list.Add(image.Id.ToString());
            }
            return list;
        }

        public int Update(string objectId, IFormFile file)
        {
            var galleryImage = _indexGalleryImage.Find(p => p.Id == ObjectId.Parse(objectId)).FirstOrDefault();
            if (galleryImage == null) return -1;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                galleryImage.Image = memoryStream.ToArray();

                var result = _indexGalleryImage.ReplaceOne(p => p.Id == ObjectId.Parse(objectId), galleryImage);
                if (!result.IsAcknowledged) return -2;
                return 1;
            }
        }
    }
}
