using personApp.DAL.DTO.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personApp.Business.Abstract
{
    public interface IAboutService
    {
        public List<GetAboutListDto> GetAboutList();
        public int AddAbout(AddAboutDto addAboutDto);
        public GetAboutDto GetAboutById(int aboutId);
        public int UpdateAbout(int id, UpdateAboutDto updateAboutDto);
        public int DeleteAbout(int id);
    }
}
