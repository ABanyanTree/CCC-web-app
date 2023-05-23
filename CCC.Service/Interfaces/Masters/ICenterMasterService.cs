using CCC.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Service.Interfaces
{
    public interface ICenterMasterService : IServiceBase<CenterMaster>
    {
        Task<string> AddEditCenter(CenterMaster obj);
        Task<CenterMaster> IsCenterNameInUse(string centerName);
        Task<IEnumerable<CenterMaster>> GetAllCenters(CenterMaster obj);
        Task<CenterMaster> IsInUseCount(string centerId);
        Task<IEnumerable<CenterMaster>> GetAllCenterByUser(CenterMaster obj);

        Task<IEnumerable<CenterMaster>> DailyDataCheck();
    }
}
