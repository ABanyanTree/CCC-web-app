using CCC.Data.Services;
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
    public class PetService : IPetServices
    {
        private IPetRepository _iPetRepository;
        public PetService(IPetRepository iPetRepository) : base()
        {
            _iPetRepository = iPetRepository;
        }

        public Task<int> AddEditAsync(PetServiceDetails obj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddEditPetData(PetServiceDetails obj)
        {
            if (string.IsNullOrEmpty(obj.ServiceId))
            {
                obj.ServiceId = Utility.GeneratorUniqueId("Pet");
                obj.IsActive = true;
            }
            int successCount = await _iPetRepository.AddEditPetData(obj);
            return successCount > 0 ? obj.ServiceId : string.Empty;
        }

        public async Task<PetServiceDetails> GetAsync(PetServiceDetails obj)
        {
            return await _iPetRepository.GetPetData(obj);
        }

        public async Task<IEnumerable<PetServiceDetails>> GetAllAsync(PetServiceDetails obj)
        {
            return await _iPetRepository.GetAllPetData(obj);
        }
        public async Task<int> DeleteAsync(PetServiceDetails obj)
        {
            return await _iPetRepository.DeletePetData(obj);
        }

        public async Task<int> ChangePetCenters(PetServiceDetails obj)
        {
            return await _iPetRepository.ChangePetCenters(obj);
        }

        public async Task<IEnumerable<PetServiceDetails>> GetVetReport(PetServiceDetails obj)
        {
            return await _iPetRepository.GetVetReport(obj);
        }

        public async Task<IEnumerable<PetServiceDetails>> GetCenterMgrDashboardList(PetServiceDetails obj)
        {
            return await _iPetRepository.GetCenterMgrDashboardList(obj);
        }

        public async Task<IEnumerable<PetServiceDetails>> GetPetCountDetails()
        {
            return await _iPetRepository.GetPetCountDetails();
        }

        public async Task<IEnumerable<PetServiceDetails>> GetCenterReportData(PetServiceDetails obj)
        {
            return await _iPetRepository.GetCenterReportData(obj);
        }

        public async Task<PetServiceDetails> IsTagIdInUse(string tagId)
        {
            return await _iPetRepository.IsTagIdInUse(tagId);
        }
    }
}
