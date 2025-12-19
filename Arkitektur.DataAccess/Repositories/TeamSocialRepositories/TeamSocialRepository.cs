using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.DataAccess.Repositories.TeamSocialRepositories
{
    public class TeamSocialRepository : GenericRepository<TeamSocial>, ITeamSocialRepository
    {
        public TeamSocialRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<TeamSocial>> GetTeamSocialsWithTeamAsync()
        {
            return await Context.Set<TeamSocial>()
                .Include(x => x.Team)
                .ToListAsync();
        }
    }
}
