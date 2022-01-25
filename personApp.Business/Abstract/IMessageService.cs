using personApp.DAL.DTO.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IMessageService
    {
        public List<GetMessageListDto> GetMessageList();
        public int AddMessage(AddMessageDto addMessageDto);
        public GetMessageDto GetMessageById(int messageId);
        public int DeleteMessage(int id);
    }
}
