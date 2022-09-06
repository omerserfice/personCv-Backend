using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using System;
using System.Collections.Generic;

namespace personApp.WebAPI.Controllers.ProjectControllerImage
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCoverImageController : ControllerBase
    {
        private readonly IProjectCoverImageService _projectCoverImageService;

        public ProjectCoverImageController(IProjectCoverImageService projectCoverImageService)
        {
            _projectCoverImageService = projectCoverImageService;
        }
        [HttpGet]
        [Route("{projectId:int}")]
        public ActionResult Get(int projectId)
        {
            try
            {
                var list = new List<string>();
                var result =  _projectCoverImageService.Get(projectId);
                if (result == null)
                {
                    list.Add("Proje resmi bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return File(result, "image/jpeg");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException);
            }
        }
        [HttpPost]
        [Route("{projectId:int}")]
        public ActionResult Add(int projectId, IFormFile file)
        {
            var list = new List<string>();

            try
            {
                var result =  _projectCoverImageService.Add(projectId, file);

                if (result == 1)
                {
                    list.Add("Ekleme İşlemi Başarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Bu projenin resmi var.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("İşlem sırasında bir hata meydana geldi");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException);
            }

        }
        [HttpPut]
        [Route("{projectId:int}")]
        public ActionResult Update(int projectId, IFormFile file)
        {
            try
            {
                var list = new List<string>();
                var result =  _projectCoverImageService.Update(projectId, file);
                if (result == 1)
                {
                    list.Add("Güncelleme İşlemi Başarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                if (result == -1)
                {
                    list.Add("Bu projeye ait resim bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Güncelleme İşlemi Başarısız.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException);
            }
        }
        [HttpDelete]
        [Route("{projectId}")]
        public ActionResult Delete(int projectId)
        {
            try
            {
                var list = new List<string>();
                var result = _projectCoverImageService.Delete(projectId);
                if (result == 1)
                {
                    list.Add("Silme İşlemi Başarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                if (result == -1)
                {
                    list.Add("Bu projeye ait resim bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Silme İşlemi Başarısız.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException);
            }
        }
    }
}
