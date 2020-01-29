using AreaManagement.Entity;
using AreaManagement.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


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
        public bool CreateArea(TblArea area)
        {
            return AreaService.CreateArea(area);
        }

        [Route("get-area-byId")]
        public TblArea GetAreaById([FromQuery(Name = "id")] int id)
        {
            return AreaService.GetAreaById(id);
        }

        [Route("get-all-areas")]
        public List<TblArea> GetAllAreas()
        {
            return AreaService.GeadAllAreas();
        }

        [Route("update-area")]
        public bool UpdateArea([FromBody] TblArea area)
        {
            return AreaService.UpdateArea(area);
        }

        [Route("delete-area")]
        public bool DeleteArea([FromQuery(Name = "id")] int id)
        {
            return AreaService.DeleteArea(id);
        }
    }
}
