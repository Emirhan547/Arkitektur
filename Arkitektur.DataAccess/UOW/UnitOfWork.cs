using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.DataAccess.UOW
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {
        public async Task<bool> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}
