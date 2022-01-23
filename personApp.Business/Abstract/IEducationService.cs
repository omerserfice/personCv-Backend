using personApp.DAL.DTO.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IEducationService
    {
        public List<GetEducationListDto> GetEducationList();
        public int AddEducation(AddEducationDto addEducationDto);
        public GetEducationDto GetEducationById(int educationId);    
        public int UpdateEducation(int id,UpdateEducationDto updateEducationDto);  
        public int DeleteEducation(int id); 
    }
}
