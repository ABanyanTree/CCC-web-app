using CCC.Domain;
using CCC.Domain.DomainInterface;
using CCC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Service.Services
{
    public class CityAreaMasterService : ICityAreaMasterService
    {
        private ICityAreaMasterRepository _iCityAreaMasterRepository;
        public CityAreaMasterService(ICityAreaMasterRepository ICityAreaMasterRepository) : base()
        {
            _iCityAreaMasterRepository = ICityAreaMasterRepository;
        }

        public async Task<int> AddEditAsync(CityAreaMaster obj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddEditCityArea(CityAreaMaster obj)
        {
            if (string.IsNullOrEmpty(obj.AreaId))
            {
                obj.AreaId = Utility.GeneratorUniqueId("ARA_");
                obj.IsActive = true;
            }
            int successCount = await _iCityAreaMasterRepository.AddEditCityArea(obj);
            return successCount > 0 ? obj.AreaId : string.Empty;
        }

        public async Task<int> DeleteAsync(CityAreaMaster obj)
        {
            return await _iCityAreaMasterRepository.DeleteCityArea(obj);
        }

        public async Task<IEnumerable<CityAreaMaster>> GetAllAsync(CityAreaMaster obj)
        {
            return await _iCityAreaMasterRepository.GetAllCityAreaList(obj);
        }

        public async Task<IEnumerable<CityAreaMaster>> GetAllCityAreas()
        {
            return await _iCityAreaMasterRepository.GetAllCityAreas();
        }

        public async Task<CityAreaMaster> GetAsync(CityAreaMaster obj)
        {
            return await _iCityAreaMasterRepository.GetCityArea(obj);
        }

        public async Task<CityAreaMaster> IsCityAreaNameInUse(string areaName)
        {
            return await _iCityAreaMasterRepository.IsCityAreaNameInUse(areaName);
        }

        public async Task<CityAreaMaster> IsInUseCount(string areaId)
        {
            return await _iCityAreaMasterRepository.IsInUseCount(areaId);
        }
    }
}
