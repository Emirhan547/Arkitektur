using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.DataAccess.UOW
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
