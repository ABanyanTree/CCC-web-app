using System.Collections.Generic;
using System.Threading.Tasks;
using CCC.Domain;

namespace CCC.Service.Interfaces
{
	public interface IPetServices : IServiceBase<PetServiceDetails>
    {
        Task<string> AddEditPetData(PetServiceDetails obj);
        Task<int> ChangePetCenters(PetServiceDetails request);
        Task<IEnumerable<PetServiceDetails>> GetVetReport(PetServiceDetails obj);
        Task<IEnumerable<PetServiceDetails>> GetCenterMgrDashboardList(PetServiceDetails searchRequest);
        Task<IEnumerable<PetServiceDetails>> GetPetCountDetails();
        Task<IEnumerable<PetServiceDetails>> GetCenterReportData(PetServiceDetails searchRequest);
        Task<PetServiceDetails> IsTagIdInUse(string tagId);
		Task<IEnumerable<PetServiceDetails>> GetAllPetReportAsync(PetServiceDetails obj);
	}
}
