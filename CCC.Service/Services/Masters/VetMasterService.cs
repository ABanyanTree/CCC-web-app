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
    public class VetMasterService : IVetMasterService
    {
        private IVetMasterRepository _iVetMasterRepository;
        public VetMasterService(IVetMasterRepository iVetMasterRepository) : base()
        {
            _iVetMasterRepository = iVetMasterRepository;
        }

        public Task<int> AddEditAsync(VetMaster obj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddEditVetDetail(VetMaster obj)
        {
            if (string.IsNullOrEmpty(obj.VetId))
            {
                obj.VetId = Utility.GeneratorUniqueId("VET_");
                obj.IsActive = true;
            }
            int successCount = await _iVetMasterRepository.AddEditVetDetail(obj);
            return successCount > 0 ? obj.VetId : string.Empty;
        }

        public async Task<int> DeleteAsync(VetMaster obj)
        {
            return await _iVetMasterRepository.DeleteVet(obj);
        }

        public async Task<IEnumerable<VetMaster>> GetAllAsync(VetMaster obj)
        {
            return await _iVetMasterRepository.GetAllVetList(obj);
        }

        public async Task<IEnumerable<VetMaster>> GetAllVetDetails()
        {
            return await _iVetMasterRepository.GetAllVetDetails();
        }

        public async Task<VetMaster> GetAsync(VetMaster obj)
        {
            return await _iVetMasterRepository.GetVetDetail(obj);
        }

        public async Task<VetMaster> IsInUseCount(string vetId)
        {
            return await _iVetMasterRepository.IsInUseCount(vetId);
        }

        public async Task<VetMaster> IsVetNameInUse(string vetName)
        {
            return await _iVetMasterRepository.IsVetNameInUse(vetName);
        }
    }
}
