using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using personApp.Business.Validation.Experience;
using personApp.DAL.DTO.Experience;
using System;
using System.Collections.Generic;

namespace personApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpGet("GetExperienceList")]
        public ActionResult<List<GetExperienceListDto>> GetExperienceList()
        {
            var list = new List<string>();
            try
            {
                var result = _experienceService.GetExperienceList();
                if (result.Count == 0)
                {
                    list.Add("Deneyim Bilgisi Bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
        [HttpGet("GetExperienceById/{id}")]
        public ActionResult<GetExperienceDto> GetExperienceById(int id)
        {
            var list = new List<string>();
            
            if (id <= 0)
            {
                list.Add("Geçersiz Id");
            }
            try
            {
                var result = _experienceService.GetExperienceById(id);
                if (result == null)
                {
                    list.Add("Deneyim Bilgisi Bulunamadı");
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

        [HttpPost("AddExperience")]
        public ActionResult<string> AddExperience(AddExperienceDto addExperienceDto)
        {
            var list = new List<string>();
            var Validator = new AddExperienceValidator();
            var validationResult = Validator.Validate(addExperienceDto);    
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
                var result = _experienceService.AddExperience(addExperienceDto);
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
        [HttpDelete("DeleteExperience/{id}")]

        public ActionResult<string> DeleteExperience(int id)
        {
            var list = new List<string>();
            if (id<=0)
            {
                list.Add("Id Geçersiz");
            }
            try
            {
                var result = _experienceService.DeleteExperience(id);
                if (result > 0)
                {
                    list.Add("Silme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Deneyim Bilgisi Bulunamadı");
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
        
        [HttpPut("UpdateExperience/{id}")]
        public ActionResult<string> UpdateExperience(int id,UpdateExperienceDto updateExperienceDto)
        {
            var list = new List<string>();
            var Validator = new UpdateExperienceValidator();
            var validationResult = Validator.Validate(updateExperienceDto);
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
                var result = _experienceService.UpdateExperience(id, updateExperienceDto);
                if (result > 0)
                {
                    list.Add("Güncelleme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Deneyim Bilgisi Bulunamadı");
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
