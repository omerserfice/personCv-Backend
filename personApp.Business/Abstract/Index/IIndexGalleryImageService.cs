using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract.Index
{
    public interface IIndexGalleryImageService
    {
        byte[] Get(string objectId);
        IEnumerable<string> Get(int IndexId);
        int Add(int IndexId, IFormFile file);
        int Update(string objectId, IFormFile file);
        int Delete(string objectId);

    }
}
