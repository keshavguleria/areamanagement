using AreaManagement.Entity;
using AreaManagement.Service;
using AreaManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private IServiceProvider service;
        private IAreaService AreaService => service.GetService(typeof(IAreaService)) as IAreaService;

        public AreaController(IServiceProvider service)
        {
            this.service = service;
        }

        [Route("create-area")]
        public async Task<bool> CreateAreaAsync(AreaViewModel areaModel)
        {
            return await AreaService.CreateAreaAsync(areaModel);
        }

        [Route("get-area-byId")]
        public async Task<AreaViewModel> GetAreaByIdAsync([FromQuery(Name = "id")] int id)
        {
            return await AreaService.GetAreaByIdAsync(id);
        }

        [Route("get-all-areas")]
        public async Task<IList<AreaViewModel>> GetAllAreasAsync()
        {
            return await AreaService.GetAllAreasAsync();
        }

        [Route("update-area")]
        public async Task<bool> UpdateAreaAsync([FromBody] AreaViewModel area)
        {
            return await AreaService.UpdateAreaAsync(area);
        }

        [Route("delete-area")]
        public async Task<bool> DeleteAreaAsync([FromQuery(Name = "id")] int id)
        {
            return await AreaService.DeleteAreaAsync(id);
        }
    }
}
