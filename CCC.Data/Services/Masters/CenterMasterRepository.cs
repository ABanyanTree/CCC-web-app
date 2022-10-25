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
    public class CenterMasterRepository : Repository<CenterMaster>, ICenterMasterRepository
    {
        public CenterMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<CenterMaster> resolver) : base(connStr, resolver)
        {
        }

        public async Task<int> AddEditCenter(CenterMaster obj)
        {
            string[] addParams = new string[]
              {
                CenterMaster_Constant.CENTERID,
                CenterMaster_Constant.CENTERNAME,
                CenterMaster_Constant.CENTERADDRESS,
                CenterMaster_Constant.DESCRIPTION,
                CenterMaster_Constant.CREATEDBY,
                CenterMaster_Constant.MODIFIEDBY,
                CenterMaster_Constant.ISACTIVE
            };

            return await ExecuteNonQueryAsync(obj, addParams, CenterMaster_Constant.SPROC_CENTERMASTER_UPS);
        }

        public async Task<CenterMaster> GetCenter(CenterMaster obj)
        {
            string[] addParams = new string[] { CenterMaster_Constant.CENTERID };
            return await GetAsync(obj, addParams, CenterMaster_Constant.SPROC_CENTERMASTER_SEL);
        }

        public async Task<IEnumerable<CenterMaster>> GetAllCenterList(CenterMaster obj)
        {
            string[] addParams = new string[] { BaseEntity_Constant.PAGEINDEX, BaseEntity_Constant.PAGESIZE, BaseEntity_Constant.SORTEXP };
            return await GetAllAsync(obj, addParams, CenterMaster_Constant.SPROC_CENTERMASTER_LSTALL);
        }

        public async Task<IEnumerable<CenterMaster>> GetAllCenters()
        {
            string[] addParams = new string[] { };
            return await GetAllAsync(new CenterMaster(), addParams, CenterMaster_Constant.SPROC_CENTERMASTER_GETALL);

        }

        public async Task<int> DeleteCenter(CenterMaster obj)
        {
            string[] addParams = new string[] { CenterMaster_Constant.CENTERID };
            return await ExecuteNonQueryAsync(obj, addParams, CenterMaster_Constant.SPROC_CENTERMASTER_DEL);
        }

        public async Task<CenterMaster> IsCenterNameInUse(string centerName)
        {
            CenterMaster obj = new CenterMaster() { CenterName = centerName };
            string[] addParams = new string[] { CenterMaster_Constant.CENTERNAME };
            return await GetAsync(obj, addParams, CenterMaster_Constant.SPROC_CENTERMASTER_ISCENTERNAMEINUSE);
        }

        public async Task<CenterMaster> IsInUseCount(string centerId)
        {
            CenterMaster obj = new CenterMaster() { CenterId = centerId };
            string[] addParams = new string[] { CenterMaster_Constant.CENTERID };
            return await GetAsync(obj, addParams, CenterMaster_Constant.SPROC_CENTERMASTER_ISINCOUNTUSE);
        }
    }
}
