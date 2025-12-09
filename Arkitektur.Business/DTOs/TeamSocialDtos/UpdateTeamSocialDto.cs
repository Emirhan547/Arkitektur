using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.TeamSocialDtos
{
    public class UpdateTeamSocialDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }

        public int TeamId { get; set; }
    }
}
