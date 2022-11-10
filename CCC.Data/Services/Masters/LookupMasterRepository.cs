using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Data.Services
{
    public class LookupMasterRepository : Repository<LookupMaster>, ILookupMasterRepository
    {
        public LookupMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<LookupMaster> resolver) : base(connStr, resolver)
        {
        }

        public async Task<IEnumerable<LookupMaster>> GetLookupByType(string lookupType)
        {
            LookupMaster obj = new LookupMaster() { LookupType = lookupType };
            string[] addParams = new string[] { LookupMaster_Constant.LOOKUPTYPE };
            return await GetAllAsync(obj, addParams, LookupMaster_Constant.SPROC_GETLOOKUPBYTYPE);
        }
    }
}
