using personAppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Entites
{
    public class Person : Audit , IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public DateTime PersonBirthDay { get; set; }
        public string PersonCity { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Ability> Abilities { get; set; }
        public ICollection<About> Abouts { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Certificates> Certificates { get; set; } 
        public ICollection<Contact> Contacts { get; set; } 
        public ICollection<Project> Projects { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
