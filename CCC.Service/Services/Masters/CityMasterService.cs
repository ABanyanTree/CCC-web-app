using CCC.Domain;
using CCC.Domain.DomainInterface;
using CCC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CCC.Service.Services
{
	public class CityMasterService : ICityMasterService
    {
        private ICityMasterRepository _iCityMasterRepository;
        public CityMasterService(ICityMasterRepository CityMasterRepository) : base()
        {
            _iCityMasterRepository = CityMasterRepository;
        }

        public Task<int> AddEditAsync(CityMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(CityMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CityMaster>> GetAllAsync(CityMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<CityMaster> GetAsync(CityMaster obj)
        {
            throw new NotImplementedException();
        }
    }
}
