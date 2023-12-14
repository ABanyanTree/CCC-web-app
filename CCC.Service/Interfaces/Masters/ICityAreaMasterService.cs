using CCC.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CCC.Service.Interfaces
{
	public interface ICityAreaMasterService : IServiceBase<CityAreaMaster>
    {
        Task<string> AddEditCityArea(CityAreaMaster obj);
        Task<CityAreaMaster> IsInUseCount(string areaId);
        Task<IEnumerable<CityAreaMaster>> GetAllCityAreas();
        Task<CityAreaMaster> IsCityAreaNameInUse(string areaName);
    }
}
