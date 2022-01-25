using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using personApp.Business.Abstract;
using personApp.Business.Validation.Message;
using personApp.DAL.DTO.Message;
using System;
using System.Collections.Generic;

namespace personApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
    [HttpGet("GetMessageList")]
    public ActionResult<List<GetMessageListDto>> GetMessageList()
        {
            var list = new List<string>();
            try
            {
                var result = _messageService.GetMessageList();
                if (result.Count == 0)
                {
                    list.Add("Mesaj Bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                return Ok(result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
     [HttpGet("GetMessageById/{id}")]
     public ActionResult<GetMessageDto> GetMessageById(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Geçersiz Id");
            }
            try
            {
                var result = _messageService.GetMessageById(id);
                if (result == null)
                {
                    list.Add("Mesaj Bulunamadı");
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

        [HttpPost("AddMessage")]
        public ActionResult<string> AddMessage(AddMessageDto addMessageDto)
        {
            var list = new List<string>();
            var Validator = new AddMessageValidator();
            var validationResult = Validator.Validate(addMessageDto);   
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
                var result = _messageService.AddMessage(addMessageDto);
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

        [HttpDelete("DeleteMessage/{id}")]
        public ActionResult<string> DeleteMessage(int id)
        {
            var list = new List<string>();
            if (id<=0)
            {
                list.Add("Geçersiz Id");
            }
            try
            {
                var result = _messageService.DeleteMessage(id);
                if (result > 0)
                {
                    list.Add("Silme İşlemi Başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("Mesaj Bulunamadı");
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
