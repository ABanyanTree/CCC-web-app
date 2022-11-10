using CCC.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CCC.Service.Interfaces
{
    public interface ILookupMasterService : IServiceBase<LookupMaster>
    {
        Task<IEnumerable<LookupMaster>> GetLookupByType(string lookupType);
    }
}
