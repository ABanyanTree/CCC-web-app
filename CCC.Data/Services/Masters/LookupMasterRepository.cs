using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;

namespace CCC.Data.Services
{
    public class LookupMasterRepository : Repository<LookupMaster>, ILookupMasterRepository
    {
        public LookupMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<LookupMaster> resolver) : base(connStr, resolver)
        {
        }
    }
}
