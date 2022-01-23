using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using personApp.Business.Validation.Education;
using personApp.Business.Validation.Person;
using personApp.DAL.DTO.Education;
using System;
using System.Collections.Generic;

namespace personApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        //Listeleme işlemi
        [HttpGet("GetListEducation")]
         public  ActionResult<List<GetEducationListDto>> GetListEducation()
        {
            var list = new List<string>();
            try
            {
                var educationList = _educationService.GetEducationList();
                if (educationList.Count == 0)
                {
                    list.Add("Eğitim Bilgisi Bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                return Ok(educationList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        // Id ye göre Eğitim Bilgilerini Getirme
       [HttpGet("GetEducationById/{id}")]
       public ActionResult<GetEducationDto> GetEducationById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Id geçersiz!");
            }
            try
            {
                var result = _educationService.GetEducationById(id);
                if (result == null)
                {
                    list.Add("Eğitim Bilgisi Bulunamadı");
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


        // Ekleme İŞlemi
       [HttpPost("AddEducation")]
       public ActionResult<string> AddEducation(AddEducationDto addEducationDto)
        {
            var list = new List<string>();
            var Validator = new AddEducationValidator();
            var validationResult = Validator.Validate(addEducationDto);
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
                var results = _educationService.AddEducation(addEducationDto);
                if (results>0)
                {
                    list.Add("Ekleme işlemi başarılı");
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
        //Güncelleme İşlemi
        [HttpPut("UpdateEducation/{id}")]

        public ActionResult<string> UpdateEducation(int id,UpdateEducationDto updateEducationDto)
        {
            var list = new List<string>();
            var Validator = new UpdateEducationValidator();
            var validatonResult = Validator.Validate(updateEducationDto);
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
                var results = _educationService.UpdateEducation(id,updateEducationDto);
                if (results > 0)
                {
                    list.Add("Güncelleme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }else if(results == -1)
                {
                    list.Add("Eğitim Bilgisi Bulunamadı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "error" });
                }
                else
                {
                    list.Add("Güncelleme İşlemi Başarısız");
                    return Ok(new { code = StatusCode(1000), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //Silme İşlemi
        [HttpDelete("DeleteEducation/{id}")]
        public ActionResult<string> DeleteEducation(int id)
        {
           var list = new List<string>();
            try
            {
                var result = _educationService.DeleteEducation(id);
                if(result > 0)
                {
                    list.Add("Silme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Eğitim Bilgisi Bulunamadı");
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
