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
    public class CenterMasterRepository : Repository<CenterMaster>, ICenterMasterRepository
    {
        public CenterMasterRepository(IOptions<ReadConfig> connStr, IDapperResolver<CenterMaster> resolver) : base(connStr, resolver)
        {
        }
    }
}
