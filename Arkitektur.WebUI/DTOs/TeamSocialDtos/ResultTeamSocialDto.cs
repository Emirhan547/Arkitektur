
using Arkitektur.WebUI.DTOs.TeamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.DTOs.TeamSocialDtos
{
    public class ResultTeamSocialDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int TeamId { get; set; }
        public ResultTeamDto Team {  get; set; }
    }
}
