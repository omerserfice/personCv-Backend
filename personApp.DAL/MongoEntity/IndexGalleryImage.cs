using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.MongoEntity
{
    public class IndexGalleryImage
    {
        public ObjectId Id { get; set; }
        public int IndexId { get; set; }
        public byte[] Image { get; set; }
    }
}
