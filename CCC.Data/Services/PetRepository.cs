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
    public class PetRepository : Repository<PetServiceDetails>, IPetRepository
    {
        public PetRepository(IOptions<ReadConfig> connStr, IDapperResolver<PetServiceDetails> resolver) : base(connStr, resolver)
        {
        }

        public async Task<int> AddEditPetData(PetServiceDetails obj)
        {
            string[] addParams = new string[]
              {
                PetServiceDetails_Constant.SERVICEID,
                PetServiceDetails_Constant.PETID,
                PetServiceDetails_Constant.GENDER,
                PetServiceDetails_Constant.CERTIFICATENO,
                PetServiceDetails_Constant.TAGID,
                PetServiceDetails_Constant.ADMISSIONDATE,
                PetServiceDetails_Constant.CENTERID,
                PetServiceDetails_Constant.AREAID,
                PetServiceDetails_Constant.CAREGIVER,
                PetServiceDetails_Constant.VETID,
                PetServiceDetails_Constant.SURGERYDATE,
                PetServiceDetails_Constant.RELEASEDATE,
                PetServiceDetails_Constant.MEDICALNOTEID,
                PetServiceDetails_Constant.VANID,
                PetServiceDetails_Constant.ISARV,
                PetServiceDetails_Constant.ISNINEINONE,
                PetServiceDetails_Constant.ISEARNOTCH,
                PetServiceDetails_Constant.ISONHOLD,
                PetServiceDetails_Constant.EXPIREDDATE,
                PetServiceDetails_Constant.CAUSEOFDEATH,
                PetServiceDetails_Constant.CREATEDBY,
                PetServiceDetails_Constant.MODIFIEDBY,
                PetServiceDetails_Constant.ISACTIVE,
                PetServiceDetails_Constant.COLOR

            };

            return await ExecuteNonQueryAsync(obj, addParams, PetServiceDetails_Constant.SPROC_PETSERVICE_UPS);

        }

        public async Task<PetServiceDetails> GetPetData(PetServiceDetails obj)
        {
            string[] addParams = new string[] { PetServiceDetails_Constant.SERVICEID };
            return await GetAsync(obj, addParams, PetServiceDetails_Constant.SPROC_PETSERVICE_SEL);
        }

        public async Task<IEnumerable<PetServiceDetails>> GetAllPetData(PetServiceDetails obj)
        {
            string[] addParams = new string[] { BaseEntity_Constant.PAGEINDEX, BaseEntity_Constant.PAGESIZE, BaseEntity_Constant.SORTEXP,
            PetServiceDetails_Constant.CENTERID,PetServiceDetails_Constant.AREAID,PetServiceDetails_Constant.ADMISSIONDATEFROM,
            PetServiceDetails_Constant.ADMISSIONDATETO,PetServiceDetails_Constant.SURGERYDATEFROM,PetServiceDetails_Constant.SURGERYDATETO,
            PetServiceDetails_Constant.RELEASEDATEFROM,PetServiceDetails_Constant.RELEASEDATETO,BaseEntity_Constant.REQUESTERUSERID,PetServiceDetails_Constant.USERCENTERS
            ,PetServiceDetails_Constant.COLOR,PetServiceDetails_Constant.SHOWRELEASEDPET,
            PetServiceDetails_Constant.TAGID
            };
            return await GetAllAsync(obj, addParams, PetServiceDetails_Constant.SPROC_PETSERVICE_LSTALL);
        }

        public async Task<IEnumerable<PetServiceDetails>> GetAllPetReportData(PetServiceDetails obj)
        {
            string[] addParams = new string[] { BaseEntity_Constant.SORTEXP, PetServiceDetails_Constant.CENTERID,PetServiceDetails_Constant.AREAID,PetServiceDetails_Constant.ADMISSIONDATEFROM,
            PetServiceDetails_Constant.ADMISSIONDATETO,PetServiceDetails_Constant.SURGERYDATEFROM,PetServiceDetails_Constant.SURGERYDATETO,
            PetServiceDetails_Constant.RELEASEDATEFROM,PetServiceDetails_Constant.RELEASEDATETO,BaseEntity_Constant.REQUESTERUSERID,PetServiceDetails_Constant.USERCENTERS
            ,PetServiceDetails_Constant.COLOR,PetServiceDetails_Constant.SHOWRELEASEDPET,
            PetServiceDetails_Constant.TAGID
            };
           
            var responce = await GetAllAsync(obj, addParams, PetServiceDetails_Constant.SPROC_PETSERVICEREPORT);
            return responce;
        }

        public async Task<int> DeletePetData(PetServiceDetails obj)
        {
            string[] addParams = new string[] { PetServiceDetails_Constant.SERVICEID };
            return await ExecuteNonQueryAsync(obj, addParams, PetServiceDetails_Constant.SPROC_PETSERVICE_DEL);
        }

        public async Task<int> ChangePetCenters(PetServiceDetails obj)
        {
            string[] addParams = new string[]
              {
                PetServiceDetails_Constant.SERVICEID,
                 PetServiceDetails_Constant.CENTERID
              };
            return await ExecuteNonQueryAsync(obj, addParams, PetServiceDetails_Constant.SPROC_CHANGECENTERFORPET);
        }

        public async Task<IEnumerable<PetServiceDetails>> GetVetReport(PetServiceDetails obj)
        {
            string[] addParams = new string[] {PetServiceDetails_Constant.CENTERID,PetServiceDetails_Constant.SURGERYDATEFROM,
                PetServiceDetails_Constant.SURGERYDATETO};
            return await GetAllAsync(obj, addParams, PetServiceDetails_Constant.SPROC_GETVETREPORT);
        }

        public async Task<IEnumerable<PetServiceDetails>> GetCenterMgrDashboardList(PetServiceDetails obj)
        {
            string[] addParams = new string[] {BaseEntity_Constant.PAGEINDEX, BaseEntity_Constant.PAGESIZE, BaseEntity_Constant.SORTEXP,
            PetServiceDetails_Constant.CENTERID,PetServiceDetails_Constant.AREAID,PetServiceDetails_Constant.USERCENTERS
           };
            return await GetAllAsync(obj, addParams, PetServiceDetails_Constant.SPROC_GETCENTERMGRDASHBOARDLIST);
        }

        public async Task<IEnumerable<PetServiceDetails>> GetPetCountDetails()
        {
            string[] addParams = new string[] { };
            return await GetAllAsync(new PetServiceDetails(), addParams, PetServiceDetails_Constant.SPROC_GETADMINDASHBOARDSUMMERYCOUNTDATA);
        }

        public async Task<IEnumerable<PetServiceDetails>> GetCenterReportData(PetServiceDetails obj)
        {
            string[] addParams = new string[]
            {
                PetServiceDetails_Constant.CENTERID
                ,PetServiceDetails_Constant.ADMISSIONDATEFROM
                ,PetServiceDetails_Constant.ADMISSIONDATETO
                ,PetServiceDetails_Constant.SURGERYDATEFROM
                ,PetServiceDetails_Constant.SURGERYDATETO
            };
            return await GetAllAsync(obj, addParams, PetServiceDetails_Constant.SPROC_GETCENTERREPORT);
        }

        public async Task<PetServiceDetails> IsTagIdInUse(string tagId)
        {
            PetServiceDetails obj = new PetServiceDetails() { TagId = tagId };
            string[] addParams = new string[] { PetServiceDetails_Constant.TAGID };
            return await GetAsync(obj, addParams, PetServiceDetails_Constant.SPROC_PETSERVICE_ISTAGIDINUSE);
        }
    }
}
