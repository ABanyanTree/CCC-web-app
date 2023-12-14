using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Domain.DomainInterface
{
	public interface IVetMasterRepository : IRepository<VetMaster>
    {
        Task<int> AddEditVetDetail(VetMaster obj);
        Task<VetMaster> IsVetNameInUse(string vetName);
        Task<VetMaster> IsInUseCount(string vetId);
        Task<VetMaster> GetVetDetail(VetMaster obj);
        Task<IEnumerable<VetMaster>> GetAllVetDetails();
        Task<IEnumerable<VetMaster>> GetAllVetList(VetMaster obj);
        Task<int> DeleteVet(VetMaster obj);
    }
}
