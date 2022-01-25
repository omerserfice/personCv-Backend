using Microsoft.EntityFrameworkCore;
using personApp.Business.Abstract;
using personApp.DAL.Context;
using personApp.DAL.DTO.Contact;
using personApp.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Concrete
{
    public class ContactService : IContactService
    {
        private readonly personAppDbContext _personAppDbContext;

        public ContactService(personAppDbContext personAppDbContext)
        {
            _personAppDbContext = personAppDbContext;
        }

        public int AddContact(AddContactDto addContactDto)
        {
           
            var newContact = new Contact
            {
                Address = addContactDto.Address,
                EMail = addContactDto.EMail,
                PhoneNumber = addContactDto.PhoneNumber,
                Twitter = addContactDto.Twitter,
                LinkedIn = addContactDto.LinkedIn,
                Instagram = addContactDto.Instagram,
                Github = addContactDto.Github,
                PersonId = addContactDto.PersonId,
            };

            
            _personAppDbContext.Contacts.Add(newContact);
            return _personAppDbContext.SaveChanges();
        }

        public int DeleteContact(int id)
        {
            var currentContact = _personAppDbContext.Contacts.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentContact == null)
            {
                return -1;
            }
            currentContact.IsDeleted = true;
            _personAppDbContext.Contacts.Update(currentContact);
            return _personAppDbContext.SaveChanges();
        }

        public GetContactDto GetContactById(int contactId)
        {
            var currentContact = _personAppDbContext.Contacts.Where(p => !p.IsDeleted && p.Id == contactId).Include(p => p.PersonFK)
           .Select(p => new GetContactDto
           {
               Id = p.Id,
               Address = p.Address, 
               EMail = p.EMail, 
               PhoneNumber = p.PhoneNumber, 
               LinkedIn = p.LinkedIn,   
               Twitter = p.Twitter,
               Instagram = p.Instagram,
               Github = p.Github,
               PersonName = p.PersonFK.PersonName,
               PersonSurname = p.PersonFK.PersonSurname,    

           }).FirstOrDefault();
            return currentContact;
         }
        public List<GetContactListDto> GetContactList()
        {
            return _personAppDbContext.Contacts.Where(p => !p.IsDeleted).Include(p=>p.PersonFK)
                .Select(p=> new GetContactListDto
                {
                    Id = p.Id,
                    Address = p.Address,
                    EMail = p.EMail,
                    PhoneNumber = p.PhoneNumber,
                    LinkedIn = p.LinkedIn,
                    Twitter = p.Twitter,
                    Instagram = p.Instagram,
                    Github = p.Github,
                    PersonName = p.PersonFK.PersonName,
                    PersonSurname = p.PersonFK.PersonSurname,

                }).ToList();
        }

        public int UpdateContact(int id, UpdateContactDto updateContactDto)
        {
            var currentContact = _personAppDbContext.Contacts.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefault();
            if (currentContact == null)
            {
                return -1;
            }
            currentContact.Address = updateContactDto.Address; 
            currentContact.PhoneNumber = updateContactDto.PhoneNumber;  
            currentContact.LinkedIn = updateContactDto.LinkedIn;    
            currentContact.Twitter = updateContactDto.Twitter;  
            currentContact.Instagram = updateContactDto.Instagram;  
            currentContact.Github = updateContactDto.Github;    
            currentContact.PersonId = updateContactDto.PersonId;    
            currentContact.MDate = DateTime.Now;

            _personAppDbContext.Contacts.Update(currentContact);
            return _personAppDbContext.SaveChanges();
        }
    }
}
