using personApp.DAL.DTO.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IExperienceService
    {
        public List<GetExperienceListDto> GetExperienceList();
        public int AddExperience(AddExperienceDto addExperienceDto);
        public GetExperienceDto GetExperienceById(int experienceId);
        public int UpdateExperience(int id, UpdateExperienceDto updateExperienceDto);
        public int DeleteExperience(int id);
    }
}
