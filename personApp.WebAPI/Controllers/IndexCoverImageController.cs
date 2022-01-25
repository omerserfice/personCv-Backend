using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using System;
using System.Collections.Generic;

namespace personApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexCoverImageController : ControllerBase
    {
        private readonly IIndexCoverImageService _ındexCoverImageService;

        public IndexCoverImageController(IIndexCoverImageService ındexCoverImageService)
        {
            _ındexCoverImageService = ındexCoverImageService;
        }

        [HttpGet("{IndexId:int}")]
        public ActionResult Get(int IndexId)
        {
            try
            {
                var list = new List<string>();
                var result = _ındexCoverImageService.Get(IndexId);
                if (result == null)
                {
                    list.Add("Index Resmi Bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return File(result, "image/jpeg");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message+ e.InnerException);   
            }
        }

        [HttpPost("{IndexId:int}")]
        public ActionResult Add(int IndexId,IFormFile file)
        {
            var list = new List<string>();
            try
            {
                var result = _ındexCoverImageService.Add(IndexId, file);
                if (result == 1)
                {
                    list.Add("Ekleme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }else if(result == -1)
                {
                    list.Add("Buna ait resim bulunmaktadır.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("İşlem sırasında hata oluştu.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException);
            }
        }
        [HttpPut("{IndexId:int}")]
        public ActionResult Update(int IndexId,IFormFile file)
        {
            try
            {
                var list = new List<string>();
                var result = _ındexCoverImageService.Update(IndexId, file);
                if (result == 1)
                {
                    list.Add("Güncellem İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Buna ait resim bulunmaktadır.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("İşlem sırasında hata oluştu.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpDelete("{IndexId}")]

        public ActionResult Delete(int IndexId)
        {
            try
            {
                var list = new List<string>();
                var result = _ındexCoverImageService.Delete(IndexId);
                if (result == 1)
                {
                    list.Add("Silme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Buna ait resim bulunmaktadır.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("İşlem sırasında hata oluştu.");
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
