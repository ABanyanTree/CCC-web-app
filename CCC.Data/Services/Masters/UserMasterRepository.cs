using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;


namespace CCC.Data.Services
{
    public class UserMasterRepository : Repository<UserMaster>, IUserMasterRepository
    {
        public UserMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<UserMaster> resolver) : base(connStr, resolver)
        {
        }
    }
}
