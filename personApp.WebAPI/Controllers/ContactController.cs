using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using personApp.Business.Validation.Contact;
using personApp.DAL.DTO.Contact;
using System;
using System.Collections.Generic;

namespace personApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("AddContact")]
        public ActionResult<string> AddContact(AddContactDto addContactDto)
        {
            var list = new List<string>();
            var Validator = new AddContactValidator();
            var validationResult = Validator.Validate(addContactDto);
            //var kayit = _contactService.GetContactList();
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
                //var kayit = _contactService.GetContactList();
                //if (kayit.Count < 2)
                //{
                    var result = _contactService.AddContact(addContactDto);
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

        [HttpGet("GetContactList")]
        public ActionResult<GetContactListDto> GetContactList()
        {
            var list = new List<string>();
            try
            {
                var result = _contactService.GetContactList();
                if (result.Count == 0)
                {
                    list.Add("İletişim Bilgisi Bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                return Ok(result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
             }
        }

        [HttpGet("GetContactById/{id}")]

        public ActionResult<GetContactDto> GetContactById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz Id");
            }
            try
            {
                var result = _contactService.GetContactById(id);
                if (result == null)
                {
                    list.Add("İletişim Bilgisi Bulunamadı");
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
        [HttpDelete("DeleteContact/{id}")]

        public ActionResult<string> DeleteContact(int id)
        {
            var list = new List<string>();
            try
            {
                var result = _contactService.DeleteContact(id);
                if (result > 0)
                {
                    list.Add("Silme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("İletişim Bilgisi Bulunamadı");
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
        [HttpPut("UpdateContact/{id}")]

        public ActionResult<string> UpdateContact(int id, UpdateContactDto updateContactDto)
        {
            var list = new List<string>();
            var Validator = new UpdateContactValidator();
            var validationResult = Validator.Validate(updateContactDto);
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

                var result = _contactService.UpdateContact(id, updateContactDto);
                if (result > 0)
                {
                    list.Add("Güncelleme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("İletişim Bilgisi Bulunamadı");
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
