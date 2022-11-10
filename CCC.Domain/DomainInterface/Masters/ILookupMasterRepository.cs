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
    }
}
