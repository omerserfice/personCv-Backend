using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using personApp.Business.Validation.Certificate;
using personApp.DAL.DTO.Certificate;
using System;
using System.Collections.Generic;

namespace personApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

    [HttpGet("GetCertificateList")]
    public ActionResult<List<GetCertificateListDto>> GetCertificateList()
        {
            var list = new List<string>();
            try
            {
                var result = _certificateService.GetCertificateList();
                if (result.Count == 0)
                {
                    list.Add("Sertifika Bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                return Ok(result);
               
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);   
            }
        }
        [HttpGet("GetCertificateById/{id}")]
        public ActionResult<GetCertificateDto> GetCertificateById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz Id");
            }
            try
            {
                var result = _certificateService.GetCertificateById(id);
                if (result == null)
                {
                    list.Add("Sertifika Bilgisi Bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    return Ok(new { code = StatusCode(1000), message = result, type = "success" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddCertificate")]
        public ActionResult<string> AddCertificate(AddCertificateDto addCertificateDto)
        {
            var list = new List<string>();
            var Validator = new AddCertificateValidator();
            var validationResult = Validator.Validate(addCertificateDto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            var result = _certificateService.AddCertificate(addCertificateDto);
            if (result > 0)
            {
                list.Add("Ekleme İşlemi Başarılı");
                return Ok(new { code = StatusCode(1000), message = list, type = "success" });
            }
            else 
            {
                list.Add("Ekleme İşlemi Başarısız");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
        }
        [HttpPut("UpdateCertificate/{id}")]
        public ActionResult<string> UpdateCertificate(int id,UpdateCertificateDto updateCertificateDto)
        {
            var list = new List<string>();
            var Validator = new UpdateCertifcateValidator();
            var validatonResult = Validator.Validate(updateCertificateDto);
            if (!validatonResult.IsValid)
            {
                foreach (var error in validatonResult.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var result = _certificateService.UpdateCertificate(id, updateCertificateDto);
                if (result > 0)
                {
                    list.Add("Güncelleme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }else if(result == -1)
                {
                    list.Add("Sertifika Bilgisi Bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Güncelleme İşlemi Başarısız");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpDelete("DeleteCertificate/{id}")]

        public ActionResult<string> DeleteCertificate(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz Id");
            }
            try
            {
                var result = _certificateService.DeleteCertificate(id);
                if (result > 0)
                {
                    list.Add("Silme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Sertifika Bilgisi Bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Silme İşlemi Başarısız");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
   
}
