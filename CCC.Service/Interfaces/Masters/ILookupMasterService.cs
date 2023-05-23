using CCC.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CCC.Service.Interfaces
{
    public interface ILookupMasterService : IServiceBase<LookupMaster>
    {
        Task<IEnumerable<LookupMaster>> GetLookupByType(string lookupType);
        Task<string> AddEditLookup(LookupMaster obj);
        Task<LookupMaster> IsInUseCount(string lookupId);
        Task<LookupMaster> IsLookupNameInUse(string lookupValue);
        Task<IEnumerable<LookupMaster>> GetLookupTypes();
        Task<IEnumerable<LookupMaster>> GetAllLookupList(LookupMaster obj);
    }
}
