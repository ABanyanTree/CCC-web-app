using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Domain.DomainInterface
{
	public interface ICityAreaMasterRepository : IRepository<CityAreaMaster>
    {
        Task<int> AddEditCityArea(CityAreaMaster obj);
        Task<CityAreaMaster> IsInUseCount(string areaId);
        Task<CityAreaMaster> IsCityAreaNameInUse(string areaName);
        Task<CityAreaMaster> GetCityArea(CityAreaMaster obj);
        Task<IEnumerable<CityAreaMaster>> GetAllCityAreas();
        Task<IEnumerable<CityAreaMaster>> GetAllCityAreaList(CityAreaMaster obj);
        Task<int> DeleteCityArea(CityAreaMaster obj);
    }
}
