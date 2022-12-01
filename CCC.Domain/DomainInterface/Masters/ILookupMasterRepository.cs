using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain.DomainInterface
{
    public interface ILookupMasterRepository : IRepository<LookupMaster>
    {
        Task<IEnumerable<LookupMaster>> GetLookupByType(string lookupType);
        Task<int> AddEditLookup(LookupMaster obj);
        Task<int> DeleteLookup(LookupMaster obj);
        Task<LookupMaster> GetLookup(LookupMaster obj);
        Task<LookupMaster> IsInUseCount(string lookupId);
        Task<LookupMaster> IsLookupNameInUse(string lookupValue);
        Task<IEnumerable<LookupMaster>> GetLookupTypes();
        Task<IEnumerable<LookupMaster>> GetAllLookupList(LookupMaster obj);
    }
}
