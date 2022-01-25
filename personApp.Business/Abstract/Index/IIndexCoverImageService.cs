using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IIndexCoverImageService
    {
        byte[] Get(int IndexId);
        int Add(int IndexId, IFormFile file);
        int Update(int IndexId, IFormFile file);
        int Delete(int IndexId);
    }
}
