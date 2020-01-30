using AreaManagement.Entity;
using AreaManagement.Service;
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
        public async Task<bool> CreateAreaAsync(TblArea area)
        {
            return await AreaService.CreateAreaAsync(area);
        }

        [Route("get-area-byId")]
        public async Task<TblArea> GetAreaByIdAsync([FromQuery(Name = "id")] int id)
        {
            return await AreaService.GetAreaByIdAsync(id);
        }

        [Route("get-all-areas")]
        public async Task<IList<TblArea>> GetAllAreasAsync()
        {
            return await AreaService.GetAllAreasAsync();
        }

        [Route("update-area")]
        public async Task<bool> UpdateAreaAsync([FromBody] TblArea area)
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
