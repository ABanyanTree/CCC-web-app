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
    public class VanMasterService : IVanMasterService
    {
        private IVanMasterRepository _iVanMasterRepository;
        public VanMasterService(IVanMasterRepository IVanMasterRepository) : base()
        {
            _iVanMasterRepository = IVanMasterRepository;
        }

        public Task<int> AddEditAsync(VanMaster obj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddEditVanDetails(VanMaster obj)
        {
            if (string.IsNullOrEmpty(obj.VanId))
            {
                obj.VanId = Utility.GeneratorUniqueId("VAN_");
                obj.IsActive = true;
            }
            int successCount = await _iVanMasterRepository.AddEditVan(obj);
            return successCount > 0 ? obj.VanId : string.Empty;
        }

        public async Task<int> DeleteAsync(VanMaster obj)
        {
            return await _iVanMasterRepository.DeleteVan(obj);
        }

        public async Task<IEnumerable<VanMaster>> GetAllAsync(VanMaster obj)
        {
            return await _iVanMasterRepository.GetAllVanDetailList(obj);
        }

        public async Task<IEnumerable<VanMaster>> GetAllVansDetails()
        {
            return await _iVanMasterRepository.GetAllVansDetails();
        }

        public async Task<VanMaster> GetAsync(VanMaster obj)
        {
            return await _iVanMasterRepository.GetVanDetail(obj);
        }

        public async Task<VanMaster> IsInUseCount(string vanId)
        {
            return await _iVanMasterRepository.IsInUseCount(vanId);
        }

        public async Task<VanMaster> IsVanNumberInUse(string vanNumber)
        {
            return await _iVanMasterRepository.IsVanNumberInUse(vanNumber);
        }
    }
}
