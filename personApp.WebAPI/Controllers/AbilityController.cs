using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using personApp.Business.Validation.Ability;
using personApp.DAL.DTO.Ability;
using System;
using System.Collections.Generic;

namespace personApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilityController : ControllerBase
    {
        private readonly IAbilityService _abilityService;

        public AbilityController(IAbilityService abilityService)
        {
            _abilityService = abilityService;
        }

        [HttpGet("GetAbilityList")]
        public ActionResult<List<GetAbilityListDto>> GetAbilityList()
        {
            var list = new List<string>();
            try
            {
                var abilityList = _abilityService.GetAbilityList();
                if (abilityList.Count == 0)
                {
                    list.Add("Yetenek Bilgisi Bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                return Ok(abilityList);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAbilityById/{id}")]
        public ActionResult<GetAbilityDto> GetAbilityById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz Id!");
            }
            try
            {
                var result = _abilityService.GetAbilityById(id);
                if (result == null)
                {
                    list.Add("Yetenek Bilgisi Bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }else 
                {
                    return Ok(new { code = StatusCode(1000), message = result, type = "success" });
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddAbility")]
        public ActionResult<string> AddAbility(AddAbilityDto addAbilityDto)
        {
            var list = new List<string>();
            var Validator = new AddAbilityValidator();
            var validationResult = Validator.Validate(addAbilityDto);
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
                var result = _abilityService.AddAbility(addAbilityDto);
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

        [HttpPut("UpdateAbility/{id}")]

        public ActionResult<string> UpdateAbility(int id,UpdateAbilityDto updateAbilityDto)
        {
            var list = new List<string>();
            var Validator = new UpdateAbilityValidator();
            var validationResult = Validator.Validate(updateAbilityDto);
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

                var result = _abilityService.UpdateAbility(id, updateAbilityDto);
                if (result > 0)
                {
                    list.Add("Ekleme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if(result == -1)
                {
                    list.Add("Yetenek Bilgisi Bulunamadı");
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

        [HttpDelete("DeleteAbility/{id}")]
        public ActionResult<string> DeleteAbility(int id)
        {
            var list = new List<string>();
            try
            {
                var result = _abilityService.DeleteAbility(id);
                if(result > 0)
                {
                    list.Add("Silme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Yetenek Bilgisi Bulunamadı");
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
