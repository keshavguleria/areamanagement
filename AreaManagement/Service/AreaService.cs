using AreaManagement.DatabaseContext;
using AreaManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreaManagement.Service
{
    public class AreaService : IAreaService
    {
        private IServiceProvider ServiceProvider { get; }
        private ApplicationDbContext Context => ServiceProvider.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
        public AreaService(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public async Task<bool> CreateAreaAsync(TblArea entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.CreatedBy = 1;
            await Context.TblAreas.AddAsync(entity);
            int saved = await Context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<IList<TblArea>> GetAllAreasAsync()
        {
            return await Context.TblAreas.ToListAsync();
        }

        public async Task<TblArea> GetAreaByIdAsync(int id)
        {
            return await Context.TblAreas.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAreaAsync(TblArea entity)
        {
            TblArea existingArea = await Context.TblAreas.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (existingArea.Id > 0)
            {
                existingArea.Name = entity.Name;
                existingArea.UpdatedOn = DateTime.UtcNow;
                existingArea.UpdatedBy = 1;
            }
            return await Context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> DeleteAreaAsync(int id)
        {
            TblArea area = await Context.TblAreas.Where(x => x.Id == id).FirstOrDefaultAsync();
            Context.TblAreas.Remove(area);
            return await Context.SaveChangesAsync() == 1 ? true : false;
        }
    }
}
