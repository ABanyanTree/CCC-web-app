using CCC.Domain;
using CCC.Domain.DomainInterface;
using CCC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Service.Services
{
    public class CityAreaMasterService : ICityAreaMasterService
    {
        private ICityAreaMasterRepository _iCityAreaMasterRepository;
        public CityAreaMasterService(ICityAreaMasterRepository ICityAreaMasterRepository) : base()
        {
            _iCityAreaMasterRepository = ICityAreaMasterRepository;
        }

        public Task<int> AddEditAsync(CityAreaMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(CityAreaMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CityAreaMaster>> GetAllAsync(CityAreaMaster obj)
        {
            throw new NotImplementedException();
        }

        public Task<CityAreaMaster> GetAsync(CityAreaMaster obj)
        {
            throw new NotImplementedException();
        }
    }
}
