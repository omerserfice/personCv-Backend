using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IProjectCoverImageService
    {
        byte[] Get(int projectId);
        int Add(int projectId, IFormFile file);
        int Update(int projectId, IFormFile file);
        int Delete(int projectId);
        
    }
}
