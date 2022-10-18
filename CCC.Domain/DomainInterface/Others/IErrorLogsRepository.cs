using CCC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain.DomainInterface
{
    public interface IErrorLogsRepository : IRepository<ErrorLogs>
    {
        Task<int> AddEditAsync(ErrorLogs obj);
        Task<IEnumerable<ErrorLogs>> GetAllAsync(ErrorLogs obj);
        Task<ErrorLogs> GetAsync(ErrorLogs obj);
    }
}
