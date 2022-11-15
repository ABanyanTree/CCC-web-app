using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Data.Services
{
    public class VanMasterRepository : Repository<VanMaster>, IVanMasterRepository
    {
        public VanMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<VanMaster> resolver) : base(connStr, resolver)
        {
        }
        public Task<int> AddEditVan(VanMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteVan(VanMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VanMaster>> GetAllVanDetailList(VanMaster obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VanMaster>> GetAllVansDetails()
        {
            string[] addParams = new string[] { };
            return await GetAllAsync(new VanMaster(), addParams, VanMaster_Constant.SPROC_VANMASTER_GETALL);
        }

        public Task<VanMaster> GetVanDetail(VanMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<VanMaster> IsInUseCount(string VanId)
        {
            throw new NotImplementedException();
        }

        public Task<VanMaster> IsVanNumberInUse(string VanNumber)
        {
            throw new NotImplementedException();
        }
    }
}
