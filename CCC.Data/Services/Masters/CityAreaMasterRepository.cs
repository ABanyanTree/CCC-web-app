using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Data.Services
{
    public class CityAreaMasterRepository : Repository<CityAreaMaster>, ICityAreaMasterRepository
    {
        public CityAreaMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<CityAreaMaster> resolver) : base(connStr, resolver)
        {
        }

        public async Task<int> AddEditCityArea(CityAreaMaster obj)
        {
            string[] addParams = new string[]
             {
                CityAreaMaster_Constant.AREAID,
                CityAreaMaster_Constant.AREANAME,
                CityAreaMaster_Constant.CITYID,
                CityAreaMaster_Constant.DESCRIPTION,
                CityAreaMaster_Constant.CREATEDBY,
                CityAreaMaster_Constant.MODIFIEDBY,
                CityAreaMaster_Constant.ISACTIVE
            };

            return await ExecuteNonQueryAsync(obj, addParams, CityAreaMaster_Constant.SPROC_CITYAREAMASTER_UPS);
        }

        public async Task<int> DeleteCityArea(CityAreaMaster obj)
        {
            string[] addParams = new string[] { CityAreaMaster_Constant.AREAID };
            return await ExecuteNonQueryAsync(obj, addParams, CityAreaMaster_Constant.SPROC_CITYAREAMASTER_DEL);
        }

        public async Task<IEnumerable<CityAreaMaster>> GetAllCityAreaList(CityAreaMaster obj)
        {
            string[] addParams = new string[] { BaseEntity_Constant.PAGEINDEX, BaseEntity_Constant.PAGESIZE, BaseEntity_Constant.SORTEXP };
            return await GetAllAsync(obj, addParams, CityAreaMaster_Constant.SPROC_CITYAREAMASTER_LSTALL);
        }

        public async Task<IEnumerable<CityAreaMaster>> GetAllCityAreas()
        {
            string[] addParams = new string[] { };
            return await GetAllAsync(new CityAreaMaster(), addParams, CityAreaMaster_Constant.SPROC_CITYAREAMASTER_GETALL);
        }

        public async Task<CityAreaMaster> GetCityArea(CityAreaMaster obj)
        {
            string[] addParams = new string[] { CityAreaMaster_Constant.AREAID };
            return await GetAsync(obj, addParams, CityAreaMaster_Constant.SPROC_CITYAREAMASTER_SEL);
        }

        public async Task<CityAreaMaster> IsCityAreaNameInUse(string areaName)
        {
            CityAreaMaster obj = new CityAreaMaster() { AreaName = areaName };
            string[] addParams = new string[] { CityAreaMaster_Constant.AREANAME };
            return await GetAsync(obj, addParams, CityAreaMaster_Constant.SPROC_CITYAREAMASTER_ISCENTERNAMEINUSE);
        }

        public async Task<CityAreaMaster> IsInUseCount(string areaId)
        {
            CityAreaMaster obj = new CityAreaMaster() { AreaId = areaId };
            string[] addParams = new string[] { CityAreaMaster_Constant.AREAID };
            return await GetAsync(obj, addParams, CityAreaMaster_Constant.SPROC_CITYAREAMASTER_ISINCOUNTUSE);
        }
    }
}
