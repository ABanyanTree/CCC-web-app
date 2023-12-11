using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Domain.DomainInterface
{
	public interface IPetRepository : IRepository<PetServiceDetails>
    {
        Task<int> AddEditPetData(PetServiceDetails obj);
        Task<PetServiceDetails> GetPetData(PetServiceDetails obj);
        Task<IEnumerable<PetServiceDetails>> GetAllPetData(PetServiceDetails obj);
        Task<IEnumerable<PetServiceDetails>> GetAllPetReportData(PetServiceDetails obj);
        Task<int> DeletePetData(PetServiceDetails obj);
        Task<int> ChangePetCenters(PetServiceDetails obj);
        Task<IEnumerable<PetServiceDetails>> GetVetReport(PetServiceDetails obj);
        Task<IEnumerable<PetServiceDetails>> GetCenterMgrDashboardList(PetServiceDetails obj);
        Task<IEnumerable<PetServiceDetails>> GetPetCountDetails();
        Task<IEnumerable<PetServiceDetails>> GetCenterReportData(PetServiceDetails obj);
        Task<PetServiceDetails> IsTagIdInUse(string tagId);
    }
}
