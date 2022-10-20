using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;

namespace CCC.Data.Services
{
    public class CityAreaMasterRepository : Repository<CityAreaMaster>, ICityAreaMasterRepository
    {
        public CityAreaMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<CityAreaMaster> resolver) : base(connStr, resolver)
        {
        }
    }
}
