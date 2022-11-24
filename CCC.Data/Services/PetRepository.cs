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
                PetServiceDetails_Constant.ISEARNOTCH,
                PetServiceDetails_Constant.ISONHOLD,
                PetServiceDetails_Constant.EXPIREDDATE,
                PetServiceDetails_Constant.CAUSEOFDEATH,
                PetServiceDetails_Constant.CREATEDBY,
                PetServiceDetails_Constant.MODIFIEDBY,
                PetServiceDetails_Constant.ISACTIVE

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
            PetServiceDetails_Constant.RELEASEDATEFROM,PetServiceDetails_Constant.RELEASEDATETO
            };
            return await GetAllAsync(obj, addParams, PetServiceDetails_Constant.SPROC_PETSERVICE_LSTALL);
        }

        public async Task<int> DeletePetData(PetServiceDetails obj)
        {
            string[] addParams = new string[] { PetServiceDetails_Constant.SERVICEID };
            return await ExecuteNonQueryAsync(obj, addParams, PetServiceDetails_Constant.SPROC_PETSERVICE_DEL);
        }
    }
}
