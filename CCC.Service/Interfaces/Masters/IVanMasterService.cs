using CCC.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CCC.Service.Interfaces
{
    public interface IVanMasterService : IServiceBase<VanMaster>
    {
        Task<string> AddEditVanDetails(VanMaster obj);
        Task<VanMaster> IsVanNumberInUse(string vanNumber);
        Task<IEnumerable<VanMaster>> GetAllVansDetails();
        Task<VanMaster> IsInUseCount(string vanId);
    }
}
