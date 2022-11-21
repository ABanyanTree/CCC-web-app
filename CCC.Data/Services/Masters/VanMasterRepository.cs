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
        public async Task<int> AddEditVan(VanMaster obj)
        {
            string[] addParams = new string[]
              {
                VanMaster_Constant.VANID,
                VanMaster_Constant.VANNUMBER,
                VanMaster_Constant.DRIVERNAME,
                VanMaster_Constant.CONTACTNO,
                VanMaster_Constant.CREATEDBY,
                VanMaster_Constant.MODIFIEDBY,
                VanMaster_Constant.ISACTIVE
            };

            return await ExecuteNonQueryAsync(obj, addParams, VanMaster_Constant.SPROC_VANMASTER_UPS);
        }

        public async Task<int> DeleteVan(VanMaster obj)
        {
            string[] addParams = new string[] { VanMaster_Constant.VANID };
            return await ExecuteNonQueryAsync(obj, addParams, VanMaster_Constant.SPROC_VANMASTER_DEL); ;
        }

        public async Task<IEnumerable<VanMaster>> GetAllVanDetailList(VanMaster obj)
        {
            string[] addParams = new string[] { BaseEntity_Constant.PAGEINDEX, BaseEntity_Constant.PAGESIZE, BaseEntity_Constant.SORTEXP,
                VanMaster_Constant.VANNUMBER };
            return await GetAllAsync(obj, addParams, VanMaster_Constant.SPROC_VANMASTER_LSTALL);
        }

        public async Task<IEnumerable<VanMaster>> GetAllVansDetails()
        {
            string[] addParams = new string[] { };
            return await GetAllAsync(new VanMaster(), addParams, VanMaster_Constant.SPROC_VANMASTER_GETALL);
        }

        public async Task<VanMaster> GetVanDetail(VanMaster obj)
        {
            string[] addParams = new string[] { VanMaster_Constant.VANID };
            return await GetAsync(obj, addParams, VanMaster_Constant.SPROC_VANMASTER_SEL);
        }

        public async Task<VanMaster> IsInUseCount(string VanId)
        {
            VanMaster obj = new VanMaster() { VanId = VanId };
            string[] addParams = new string[] { VanMaster_Constant.VANID };
            return await GetAsync(obj, addParams, VanMaster_Constant.SPROC_VANMASTER_ISINCOUNTUSE);
        }

        public async Task<VanMaster> IsVanNumberInUse(string VanNumber)
        {
            VanMaster obj = new VanMaster() { VanNumber = VanNumber };
            string[] addParams = new string[] { VanMaster_Constant.VANNUMBER };
            return await GetAsync(obj, addParams, VanMaster_Constant.SPROC_VANMASTER_ISVANNUMBERINUSE);
        }
    }
}
