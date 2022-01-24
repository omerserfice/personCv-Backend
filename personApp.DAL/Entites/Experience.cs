using personAppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.DAL.Entites
{
    public class Experience : Audit,IEntity,ISoftDeleted
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Departman { get; set; }
        public string WorkPosition { get; set; }
        public string WorkDetail { get; set; }
        public DateTime StartDateOfWork  { get; set; }
        public DateTime EndDateOfWork  { get; set; }
        public bool Status { get; set; }
        public int PersonId { get; set; }
        public Person PersonFK { get; set; }
       
        public bool IsDeleted { get; set; }
    }
}
