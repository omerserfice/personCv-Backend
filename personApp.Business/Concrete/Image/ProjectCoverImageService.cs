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

namespace personApp.Business.Concrete.Image
{
    public class ProjectCoverImageService : IProjectCoverImageService
    {
        private readonly IMongoCollection<ProjectCoverImage> _projectCoverImage;

        public ProjectCoverImageService(IMongoDbContext mongoDbContext)
        {
            _projectCoverImage = mongoDbContext.GetCollection<ProjectCoverImage>();
        }

        public int Add(int projectId, IFormFile file)
        {
           
            var coverObject =  _projectCoverImage.Find(p => p.ProjectId == projectId).FirstOrDefault();
            if (coverObject != null) return -1;          

            using (var memoryStream = new MemoryStream())
            {
                 file.CopyToAsync(memoryStream);
                var newCoverObject = new ProjectCoverImage
                {
                    Id = ObjectId.GenerateNewId(),
                    ProjectId = projectId,
                    Image = memoryStream.ToArray()
                };
               
                _projectCoverImage.InsertOne(newCoverObject);
            }
            return 1;

        }

        public int Delete(int projectId)
        {
            var coverObject =  _projectCoverImage.Find(p => p.ProjectId == projectId).FirstOrDefault();
            if (coverObject == null) return -1;

            var result = _projectCoverImage.DeleteOne(p => p.ProjectId == projectId);
            if (!result.IsAcknowledged) return -2;
            return 1;
        }

        public byte[] Get(int projectId)
        {
            var coverObject = _projectCoverImage.Find(p => p.ProjectId == projectId).FirstOrDefault();
            if (coverObject == null) return null;
            return coverObject.Image;
        }

        public int Update(int projectId, IFormFile file)
        {
            var coverObject =  _projectCoverImage.Find(p => p.ProjectId == projectId).FirstOrDefault();
            if (coverObject == null) return -1;

            using (var memoryStream = new MemoryStream())
            {
                 file.CopyToAsync(memoryStream);
                coverObject.Image = memoryStream.ToArray();

                var result =  _projectCoverImage.ReplaceOne(p => p.ProjectId == projectId, coverObject);

                if (!result.IsAcknowledged) return -2;
                return 1;
            }
        }
    }
}
