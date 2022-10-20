using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;

namespace CCC.Data.Services
{
    public class VetMasterRepository : Repository<VetMaster>, IVetMasterRepository
    {
        public VetMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<VetMaster> resolver) : base(connStr, resolver)
        {

        }
    }
}
