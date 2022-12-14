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
    public class CenterMasterService : ICenterMasterService
    {
        private ICenterMasterRepository _iCenterMasterRepository;
        public CenterMasterService(ICenterMasterRepository ICenterMasterRepository) : base()
        {
            _iCenterMasterRepository = ICenterMasterRepository;
        }

        public Task<int> AddEditAsync(CenterMaster obj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddEditCenter(CenterMaster obj)
        {
            if (string.IsNullOrEmpty(obj.CenterId))
            {
                obj.CenterId = Utility.GeneratorUniqueId("CNT_");
                obj.IsActive = true;
            }
            int successCount = await _iCenterMasterRepository.AddEditCenter(obj);
            return successCount > 0 ? obj.CenterId : string.Empty;
        }

        public async Task<int> DeleteAsync(CenterMaster obj)
        {
            return await _iCenterMasterRepository.DeleteCenter(obj);
        }

        public async Task<IEnumerable<CenterMaster>> GetAllAsync(CenterMaster obj)
        {
            return await _iCenterMasterRepository.GetAllCenterList(obj);
        }

        public async Task<IEnumerable<CenterMaster>> GetAllCenterByUser(CenterMaster obj)
        {
            return await _iCenterMasterRepository.GetAllCenterByUser(obj);
        }

        public async Task<IEnumerable<CenterMaster>> GetAllCenters(CenterMaster obj)
        {
            return await _iCenterMasterRepository.GetAllCenters(obj);
        }

        public async Task<CenterMaster> GetAsync(CenterMaster obj)
        {
            return await _iCenterMasterRepository.GetCenter(obj);
        }

        public async Task<CenterMaster> IsCenterNameInUse(string centerName)
        {
            return await _iCenterMasterRepository.IsCenterNameInUse(centerName);
        }

        public async Task<CenterMaster> IsInUseCount(string centerId)
        {
            return await _iCenterMasterRepository.IsInUseCount(centerId);
        }
    }
}
