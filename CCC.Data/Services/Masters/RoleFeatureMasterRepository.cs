using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;


namespace CCC.Data.Services
{
    public class RoleFeatureMasterRepository : Repository<RoleFeatureMaster>, IRoleFeatureMasterRepository
    {
        public RoleFeatureMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<RoleFeatureMaster> resolver) : base(connStr, resolver)
        {
        }
    }
}
