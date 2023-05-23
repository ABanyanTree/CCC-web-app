using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Data.Services
{
    public class LookupMasterRepository : Repository<LookupMaster>, ILookupMasterRepository
    {
        public LookupMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<LookupMaster> resolver) : base(connStr, resolver)
        {
        }

        public async Task<int> AddEditLookup(LookupMaster obj)
        {
            string[] addParams = new string[]
             {
                LookupMaster_Constant.LOOKUPID,
                LookupMaster_Constant.LOOKUPTYPE,
                LookupMaster_Constant.LOOKUPVALUE,
                LookupMaster_Constant.ISACTIVE
            };

            return await ExecuteNonQueryAsync(obj, addParams, LookupMaster_Constant.SPROC_LOOKUPMASTER_UPS);
        }

        public async Task<int> DeleteLookup(LookupMaster obj)
        {
            string[] addParams = new string[] { LookupMaster_Constant.LOOKUPID };
            return await ExecuteNonQueryAsync(obj, addParams, LookupMaster_Constant.SPROC_LOOKUPMASTER_DEL);
        }

        public async Task<IEnumerable<LookupMaster>> GetAllLookupList(LookupMaster obj)
        {
            string[] addParams = new string[] { BaseEntity_Constant.PAGEINDEX, BaseEntity_Constant.PAGESIZE, BaseEntity_Constant.SORTEXP, LookupMaster_Constant.LOOKUPTYPE };
            return await GetAllAsync(obj, addParams, LookupMaster_Constant.SPROC_LOOKUPMASTER_LSTALL);
        }

        public async Task<LookupMaster> GetLookup(LookupMaster obj)
        {
            string[] addParams = new string[] { LookupMaster_Constant.LOOKUPID };
            return await GetAsync(obj, addParams, LookupMaster_Constant.SPROC_LOOKUPMASTER_SEL);
        }

        public async Task<IEnumerable<LookupMaster>> GetLookupByType(string lookupType)
        {
            LookupMaster obj = new LookupMaster() { LookupType = lookupType };
            string[] addParams = new string[] { LookupMaster_Constant.LOOKUPTYPE };
            return await GetAllAsync(obj, addParams, LookupMaster_Constant.SPROC_GETLOOKUPBYTYPE);
        }

        public async Task<IEnumerable<LookupMaster>> GetLookupTypes()
        {
            string[] addParams = new string[] { };
            return await GetAllAsync(new LookupMaster(), addParams, LookupMaster_Constant.SPROC_GETLOOKUPTYPES_LSTALL);
        }

        public async Task<LookupMaster> IsInUseCount(string lookupId)
        {
            LookupMaster obj = new LookupMaster() { LookupId = lookupId };
            string[] addParams = new string[] { LookupMaster_Constant.LOOKUPID };
            return await GetAsync(obj, addParams, LookupMaster_Constant.SPROC_LOOKUPMASTER_ISINCOUNTUSE);
        }

        public async Task<LookupMaster> IsLookupNameInUse(string lookupValue)
        {
            LookupMaster obj = new LookupMaster() { LookupValue = lookupValue };
            string[] addParams = new string[] { LookupMaster_Constant.LOOKUPVALUE };
            return await GetAsync(obj, addParams, LookupMaster_Constant.SPROC_LOOKUPMASTER_ISLOOKUPVALUEINUSE);
        }
    }
}
