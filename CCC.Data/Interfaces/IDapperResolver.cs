using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Data.Interfaces
{
    public interface IDapperResolver<T>
    {
        DynamicParameters GetParameters(string[] addParams, T entity);
    }
}
