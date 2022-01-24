using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using personApp.Business.Validation.About;
using personApp.DAL.DTO.About;
using System;
using System.Collections.Generic;

namespace personApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("GetAboutList")]
        public ActionResult<List<GetAboutListDto>> GetAboutList()
        {
            var list = new List<string>();
            try
            {
                var result = _aboutService.GetAboutList();
                if (result.Count == 0)
                {
                    list.Add("Hakkımızda Bilgisi Bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                return Ok(result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        [HttpGet("GetAbilityById/{id}")]
        public ActionResult<GetAboutDto> GetAbilityById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz Id");
            }
            try
            {
                var result = _aboutService.GetAboutById(id);
                if (result == null)
                {
                    list.Add("Hakkımızda Bilgisi Bulunamadı");
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

        [HttpPost("AddAbout")]

        public ActionResult<string> AddAbout(AddAboutDto addAboutDto)
        {
            var list = new List<string>();
            var Validator = new AddAboutValidator();
            var validationResult = Validator.Validate(addAboutDto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var result = _aboutService.AddAbout(addAboutDto);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeleteAbout/{id}")]

        public ActionResult<string> DeleteAbout(int id)
        {
            var list =new List<string>();
            try
            {
                var result = _aboutService.DeleteAbout(id);
                if (result > 0)
                {
                    list.Add("Silme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Hakkımızda Bilgisi Bulunamadı");
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
        [HttpPut("UpdateAbout/{id}")]

        public ActionResult<string> UpdateAbout(int id,UpdateAboutDto updateAboutDto)
        {
            var list = new List<string>();
            var Validator = new UpdateAboutValidator();
            var validationResult = Validator.Validate(updateAboutDto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var result = _aboutService.UpdateAbout(id, updateAboutDto);
                if (result > 0)
                {
                    list.Add("Güncelleme  İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Hakkımda Bilgisi Bulunamadı");
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
    }
}
