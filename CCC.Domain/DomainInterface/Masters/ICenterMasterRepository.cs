using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain.DomainInterface
{
    public interface ICenterMasterRepository : IRepository<CenterMaster>
    {
        Task<int> AddEditCenter(CenterMaster obj);
        Task<CenterMaster> GetCenter(CenterMaster obj);
        Task<IEnumerable<CenterMaster>> GetAllCenterList(CenterMaster obj);
        Task<int> DeleteCenter(CenterMaster obj);
        Task<IEnumerable<CenterMaster>> GetAllCenters();
        Task<CenterMaster> IsCenterNameInUse(string centerName);
        Task<CenterMaster> IsInUseCount(string centerId);
        Task<IEnumerable<CenterMaster>> GetAllCenterByUser(CenterMaster obj);
    }
}
