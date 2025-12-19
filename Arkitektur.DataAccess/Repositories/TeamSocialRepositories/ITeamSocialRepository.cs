using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.DataAccess.Repositories.TeamSocialRepositories
{
    public interface ITeamSocialRepository:IGenericRepository<TeamSocial>
    {
        Task<List<TeamSocial>> GetTeamSocialsWithTeamAsync();
    }
}
