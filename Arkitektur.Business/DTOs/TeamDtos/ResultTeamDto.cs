using Arkitektur.Business.DTOs.TeamSocialDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.TeamDtos
{
    public class ResultTeamDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public IList<ResultTeamSocialDto>TeamSocials { get; set; }
    }
}
