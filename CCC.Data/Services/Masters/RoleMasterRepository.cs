using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;

namespace CCC.Data.Services
{
    public class RoleMasterRepository : Repository<RoleMaster>, IRoleMasterRepository
    {
        public RoleMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<RoleMaster> resolver) : base(connStr, resolver)
        {
        }
    }
}
