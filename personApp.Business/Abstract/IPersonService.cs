using personApp.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IPersonService
    {
        
        public List<GetPersonListDto> GetPersonList();
        public GetPersonDto GetPersonById(int personId);
        int AddPerson(AddPersonDto addPersonDto);
        int UpdatePerson(int id,UpdatePersonDto updatePersonDto);
        int DeletePerson(int personId);

        
     }
}
