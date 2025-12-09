
using Arkitektur.WebUI.DTOs.TeamSocialDtos;


namespace Arkitektur.WebUI.DTOs.TeamDtos
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
