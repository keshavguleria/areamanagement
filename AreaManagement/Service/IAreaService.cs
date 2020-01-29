using AreaManagement.Entity;
using System.Collections.Generic;

namespace AreaManagement.Service
{
    public interface IAreaService
    {
        bool CreateArea(TblArea entity);
        List<TblArea> GeadAllAreas();
        TblArea GetAreaById(int id);
        bool UpdateArea(TblArea entity);
        bool DeleteArea(int id);
    }
}
