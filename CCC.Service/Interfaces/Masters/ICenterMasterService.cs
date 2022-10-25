﻿using CCC.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCC.Service.Interfaces
{
    public interface ICenterMasterService : IServiceBase<CenterMaster>
    {
        Task<string> AddEditCenter(CenterMaster obj);
        Task<CenterMaster> IsCenterNameInUse(string centerName);
        Task<IEnumerable<CenterMaster>> GetAllCenters();
        Task<CenterMaster> IsInUseCount(string centerId);
    }
}