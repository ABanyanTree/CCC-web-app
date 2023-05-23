using CCC.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Service.Interfaces
{
    public interface IVetMasterService : IServiceBase<VetMaster>
    {
        Task<string> AddEditVetDetail(VetMaster obj);
        Task<VetMaster> IsInUseCount(string vetId);
        Task<IEnumerable<VetMaster>> GetAllVetDetails();
        Task<VetMaster> IsVetNameInUse(string vetName);
    }
}
