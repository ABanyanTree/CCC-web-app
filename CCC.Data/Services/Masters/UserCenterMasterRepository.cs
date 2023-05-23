using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;

namespace CCC.Data.Services
{
    public class UserCenterMasterRepository : Repository<UserCenterMaster>, IUserCenterMasterRepository
    {
        public UserCenterMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<UserCenterMaster> resolver) : base(connStr, resolver)
        {
        }
    }
}
