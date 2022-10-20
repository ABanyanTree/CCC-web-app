using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;


namespace CCC.Data.Services
{
    public class UserRoleMastersRepository : Repository<UserRoleMasters>, IUserRoleMastersRepository
    {
        public UserRoleMastersRepository(IOptions<ReadConfig> connStr, IDapperResolver<UserRoleMasters> resolver) : base(connStr, resolver)
        {
        }
    }
}
