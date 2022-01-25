using personApp.DAL.DTO.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IContactService
    {
        public List<GetContactListDto> GetContactList();
        public int AddContact(AddContactDto addContactDto);
        public GetContactDto GetContactById(int contactId);
        public int UpdateContact(int id, UpdateContactDto updateContactDto);
        public int DeleteContact(int id);
    }
}
