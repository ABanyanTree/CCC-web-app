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
    public class ErrorLogsService : IErrorLogs
    {
        private IErrorLogsRepository _errorLogsRepository;


        public ErrorLogsService(IErrorLogsRepository userRepository
             )
            : base()
        {
            _errorLogsRepository = userRepository;
        }

        public async Task<int> AddEditAsync(ErrorLogs obj)
        {
            return await _errorLogsRepository.AddEditAsync(obj);
        }

        public Task<int> DeleteAsync(ErrorLogs obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ErrorLogs>> GetAllAsync(ErrorLogs obj)
        {
            return await _errorLogsRepository.GetAllAsync(obj);
        }

        public async Task<ErrorLogs> GetAsync(ErrorLogs obj)
        {
            return await _errorLogsRepository.GetAsync(obj);
        }
    }
}
