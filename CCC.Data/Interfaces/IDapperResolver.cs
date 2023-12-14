using Dapper;

namespace CCC.Data.Interfaces
{
	public interface IDapperResolver<T>
    {
        DynamicParameters GetParameters(string[] addParams, T entity);
    }
}
