using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.DataAccess.Repositories.UserMessageRepositories
{
    public class UserMessageRepository : GenericRepository<UserMessage>, IUserMessageRepository
    {
        public UserMessageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
