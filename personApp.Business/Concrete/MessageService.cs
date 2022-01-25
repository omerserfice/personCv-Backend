using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.DTO.Message;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly personAppDbContext _personAppDbContext;

        public MessageService(personAppDbContext personAppDbContext)
        {
            _personAppDbContext = personAppDbContext;
        }

        public int AddMessage(AddMessageDto addMessageDto)
        {
            var newMessage = new Message
            {
                Name = addMessageDto.Name,
                Surname = addMessageDto.Surname,    
                Mail = addMessageDto.Mail,  
                PhoneNumber = addMessageDto.PhoneNumber,
                Subject = addMessageDto.Subject,    
                MessageDetail = addMessageDto.MessageDetail,
            };
            _personAppDbContext.Messages.Add(newMessage);
            return _personAppDbContext.SaveChanges();   

        }

        public int DeleteMessage(int id)
        {
            var currentMessage = _personAppDbContext.Messages.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentMessage == null)
            {
                return -1;
            }
            currentMessage.IsDeleted = true;
            _personAppDbContext.Messages.Update(currentMessage);
            return _personAppDbContext.SaveChanges();

        }

        public GetMessageDto GetMessageById(int messageId)
        {
            var currentMessage = _personAppDbContext.Messages.Where(p => !p.IsDeleted && p.Id == messageId)
                .Select(p => new GetMessageDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,    
                    Mail = p.Mail,  
                    PhoneNumber= p.PhoneNumber, 
                    Subject = p.Subject,
                    MessageDetail= p.MessageDetail, 

                }).FirstOrDefault();
            return currentMessage;
        }

        public List<GetMessageListDto> GetMessageList()
        {
            return _personAppDbContext.Messages.Where(p => !p.IsDeleted)
                .Select(p => new GetMessageListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Mail = p.Mail,
                    PhoneNumber = p.PhoneNumber,
                    Subject = p.Subject,
                    MessageDetail = p.MessageDetail,

                }).ToList();    
        }
    }
}
