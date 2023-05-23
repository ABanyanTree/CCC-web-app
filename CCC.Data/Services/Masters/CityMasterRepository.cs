using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;
namespace CCC.Data.Services
{
    public class CityMasterRepository : Repository<CityMaster>, ICityMasterRepository
    {
        public CityMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<CityMaster> resolver) : base(connStr, resolver)
        {
        }
    }
}
