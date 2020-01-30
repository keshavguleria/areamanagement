using AreaManagement.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreaManagement.Service
{
    public interface IAreaService
    {
        Task<bool> CreateAreaAsync(AreaViewModel entity);
        Task<IList<AreaViewModel>> GetAllAreasAsync();
        Task<AreaViewModel> GetAreaByIdAsync(int id);
        Task<bool> UpdateAreaAsync(AreaViewModel entity);
        Task<bool> DeleteAreaAsync(int id);
    }
}
