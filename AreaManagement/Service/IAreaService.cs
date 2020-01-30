using AreaManagement.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreaManagement.Service
{
    public interface IAreaService
    {
        Task<bool> CreateAreaAsync(TblArea entity);
        Task<IList<TblArea>> GetAllAreasAsync();
        Task<TblArea> GetAreaByIdAsync(int id);
        Task<bool> UpdateAreaAsync(TblArea entity);
        Task<bool> DeleteAreaAsync(int id);
    }
}
