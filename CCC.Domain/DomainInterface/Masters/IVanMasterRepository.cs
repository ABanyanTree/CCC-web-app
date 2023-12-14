using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Domain.DomainInterface
{
	public interface IVanMasterRepository : IRepository<VanMaster>
    {
        Task<int> AddEditVan(VanMaster obj);
        Task<VanMaster> GetVanDetail(VanMaster obj);
        Task<IEnumerable<VanMaster>> GetAllVanDetailList(VanMaster obj);
        Task<int> DeleteVan(VanMaster obj);
        Task<IEnumerable<VanMaster>> GetAllVansDetails();
        Task<VanMaster> IsVanNumberInUse(string VanNumber);
        Task<VanMaster> IsInUseCount(string VanId);
    }
}
