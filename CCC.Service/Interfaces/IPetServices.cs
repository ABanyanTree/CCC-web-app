using CCC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Service.Interfaces
{
    public interface IPetServices : IServiceBase<PetServiceDetails>
    {
        Task<string> AddEditPetData(PetServiceDetails obj);
        Task<int> ChangePetCenters(PetServiceDetails request);
        Task<IEnumerable<PetServiceDetails>> GetVetReport(PetServiceDetails obj);
        Task<IEnumerable<PetServiceDetails>> GetCenterMgrDashboardList(PetServiceDetails searchRequest);
        Task<IEnumerable<PetServiceDetails>> GetPetCountDetails();
    }
}
