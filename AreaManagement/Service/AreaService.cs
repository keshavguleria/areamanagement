using AreaManagement.DatabaseContext;
using AreaManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool CreateArea(TblArea entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.CreatedBy = 1;
            Context.TblAreas.Add(entity);
            return Context.SaveChanges() > 0 ? true : false;
        }

        public List<TblArea> GeadAllAreas()
        {
            var v = Context.TblAreas.ToList();
            return v;
        }

        public TblArea GetAreaById(int id)
        {
            return Context.TblAreas.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool UpdateArea(TblArea entity)
        {
            TblArea existingArea = Context.TblAreas.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (existingArea.Id > 0)
            {
                existingArea.Name = entity.Name;
                existingArea.UpdatedOn = DateTime.UtcNow;
                existingArea.UpdatedBy = 1;
            }
            Context.Entry(existingArea).State = EntityState.Modified;
            return Context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteArea(int id)
        {
            TblArea area = Context.TblAreas.Where(x => x.Id == id).FirstOrDefault();
            Context.TblAreas.Remove(area);
            return Context.SaveChanges() == 1 ? true : false;
        }
    }
}
