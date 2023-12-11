using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Service.Interfaces
{
	public interface IServiceBase<T>
	{
		Task<T> GetAsync(T obj);
		Task<int> AddEditAsync(T obj);
		Task<int> DeleteAsync(T obj);
		Task<IEnumerable<T>> GetAllAsync(T obj);
	}
}
