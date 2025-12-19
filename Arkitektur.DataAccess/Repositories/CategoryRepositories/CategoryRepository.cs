using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.DataAccess.Repositories.CategoryRepositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetCategoriesWithProjectsAsync()
        {
            return await Context.Set<Category>()
                .Include(x => x.Projects)
                .ToListAsync();
        }
    }
}
