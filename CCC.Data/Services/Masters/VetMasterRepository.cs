using CCC.Data.Interfaces;
using CCC.Domain;
using CCC.Domain.DomainInterface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Data.Services
{
    public class VetMasterRepository : Repository<VetMaster>, IVetMasterRepository
    {
        public VetMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<VetMaster> resolver) : base(connStr, resolver)
        {

        }

        public async Task<int> AddEditVetDetail(VetMaster obj)
        {
            string[] addParams = new string[]
              {
                VetMaster_Constant.VETID,
                VetMaster_Constant.VETNAME,
                VetMaster_Constant.EMAIL,
                VetMaster_Constant.MOBILE,
                VetMaster_Constant.ADDRESS,
                VetMaster_Constant.DESCRIPTION,
                VetMaster_Constant.CREATEDBY,
                VetMaster_Constant.MODIFIEDBY,
                VetMaster_Constant.ISACTIVE
            };

            return await ExecuteNonQueryAsync(obj, addParams, VetMaster_Constant.SPROC_VETMASTER_UPS);
        }

        public async Task<int> DeleteVet(VetMaster obj)
        {
            string[] addParams = new string[] { VetMaster_Constant.VETID };
            return await ExecuteNonQueryAsync(obj, addParams, VetMaster_Constant.SPROC_VETMASTER_DEL);
        }

        public async Task<IEnumerable<VetMaster>> GetAllVetDetails()
        {
            string[] addParams = new string[] { };
            return await GetAllAsync(new VetMaster(), addParams, VetMaster_Constant.SPROC_VETMASTER_GETALL);
        }

        public async Task<IEnumerable<VetMaster>> GetAllVetList(VetMaster obj)
        {
            string[] addParams = new string[] { BaseEntity_Constant.PAGEINDEX, BaseEntity_Constant.PAGESIZE, BaseEntity_Constant.SORTEXP,
            VetMaster_Constant.VETNAME};
            return await GetAllAsync(obj, addParams, VetMaster_Constant.SPROC_VETMASTER_LSTALL);
        }

        public async Task<VetMaster> GetVetDetail(VetMaster obj)
        {
            string[] addParams = new string[] { VetMaster_Constant.VETID };
            return await GetAsync(obj, addParams, VetMaster_Constant.SPROC_VETMASTER_SEL);
        }

        public async Task<VetMaster> IsInUseCount(string vetId)
        {
            VetMaster obj = new VetMaster() { VetId = vetId };
            string[] addParams = new string[] { VetMaster_Constant.VETID };
            return await GetAsync(obj, addParams, VetMaster_Constant.SPROC_VETMASTER_ISINCOUNTUSE);
        }

        public async Task<VetMaster> IsVetNameInUse(string vetName)
        {
            VetMaster obj = new VetMaster() { VetName = vetName };
            string[] addParams = new string[] { VetMaster_Constant.VETNAME };
            return await GetAsync(obj, addParams, VetMaster_Constant.SPROC_VETMASTER_ISVETNAMEINUSE);
        }
    }
}
