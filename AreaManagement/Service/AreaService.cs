using AreaManagement.DatabaseContext;
using AreaManagement.Entity;
using AreaManagement.ViewModel;
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

        public async Task<bool> CreateAreaAsync(AreaViewModel model)
        {
            var entity = new TblArea
            {
                Name = model.AreaName,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = 1
            };
            await Context.TblAreas.AddAsync(entity);
            int saved = await Context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<IList<AreaViewModel>> GetAllAreasAsync()
        {
            var result = await Context.TblAreas.ToListAsync();
            var areas = new List<AreaViewModel>();
            foreach (var item in result)
            {
                var area = new AreaViewModel
                {
                    Id = item.Id,
                    AreaName = item.Name,
                    CreatedBy = item.CreatedBy,
                    CreatedOn = item.CreatedOn,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedOn = item.UpdatedOn
                };
                areas.Add(area);
            }

            return areas;
        }

        public async Task<AreaViewModel> GetAreaByIdAsync(int id)
        {
            var result = await Context.TblAreas.Where(x => x.Id == id).FirstOrDefaultAsync();
            var area = new AreaViewModel();
            if (result != null)
            {
                area.Id = result.Id;
                area.AreaName = result.Name;
                area.CreatedBy = result.CreatedBy;
                area.CreatedOn = result.CreatedOn;
                area.UpdatedBy = result.UpdatedBy;
                area.UpdatedOn = result.UpdatedOn;
            }
            return area;
        }

        public async Task<bool> UpdateAreaAsync(AreaViewModel entity)
        {
            TblArea existingArea = await Context.TblAreas.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (existingArea.Id > 0)
            {
                existingArea.Name = entity.AreaName;
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
