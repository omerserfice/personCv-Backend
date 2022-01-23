using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using personApp.Business.Validation.Person;
using personApp.DAL.DTO;
using System;
using System.Collections.Generic;

namespace personApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet("GetListPerson")]
        public ActionResult<List<GetPersonListDto>> GetListPerson()
        {
            var list = new List<string>(); // 1. List tanımlıyoruz.
            try
            {
                var personList = _personService.GetPersonList(); //servisden gelen değerleri değişkene atıyoruz.
                if (personList.Count == 0) // eğer içinde kayıt yoksa içerik bulunmadı yazsın.
                {
                    list.Add("Kişi listesine ait içerik bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });// durum kodu dönsün.
                }
                return Ok(personList); // listin içi doluysa Ok dönsün.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // hata mesajları dönsün.
            }
        } 

        [HttpGet("GetPersonById/{id}")]

        public ActionResult<GetPersonDto> GetPersonById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Kişi Id si geçersiz");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            try
            {
                var result = _personService.GetPersonById(id);
                if (result == null)
                {
                    list.Add("Kişi bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else{
                    return Ok(new { code = StatusCode(1000), message = result, type = "success" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddPerson")]
        public ActionResult<string> AddPerson(AddPersonDto addPersonDto)
        {
            var list = new List<string>();
            var Validator = new AddPersonValidator();
            var validationResult = Validator.Validate(addPersonDto);
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
                var results = _personService.AddPerson(addPersonDto);
                if (results>0)
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
        [HttpDelete("DeletePerson/{id}")]
        public ActionResult<string> DeletePerson(int id)
        {
            var list = new List<string>();
            try
            {
                var result = _personService.DeletePerson(id);
                if (result > 0)
                {
                    list.Add("Silme işlemi başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Kişi Bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Silme İşlemi Başarısız.");
                    return Ok(new { code = StatusCode(1002), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePerson/{id}")]

        public ActionResult<string> UpdatePerson(int id,UpdatePersonDto updatePersonDto)
        {
            var list = new List<string>();
            var Validator = new UpdatePersonValidator();
            var validationResult = Validator.Validate(updatePersonDto);

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
                    var result = _personService.UpdatePerson(id,updatePersonDto);
                    if (result > 0)
                    {
                        list.Add("Güncelleme İşlemi Başarılı");
                        return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                    }
                    else if (result == -1)
                    {
                        list.Add("Kişi bulunamadı.");
                        return Ok(new { code = StatusCode(1001), message = list, type = "error " });
                    }
                    else
                    {

                        list.Add("Güncelleme İşlemi Başarısız.");
                        return Ok(new { code = StatusCode(1002), message = list, type = "error " });

                    }
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
        }

    }

