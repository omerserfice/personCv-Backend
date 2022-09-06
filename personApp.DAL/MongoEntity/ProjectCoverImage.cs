using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.MongoEntity
{   /// <summary>
   /// mongo collection örneği 
   /// </summary>
    public class ProjectCoverImage
    {
        /// <summary>
        /// mongo için kullanılacak id
        /// </summary>
        public ObjectId Id { get; set; }
        /// <summary>
        /// resim örenği için kullanılacak id
        /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// resmin kendisi mongoda byte[] olarak tutulur.
        /// </summary>
        public byte[] Image { get; set; }

    }
}
