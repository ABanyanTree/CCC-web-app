using CCC.UI.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CCC.UI.RefitClientFactory
{
    [Headers("Authorization: Bearer")]
    public interface ICenterMasterApi
    {
        [Get(path: "/api/centerMaster/getallcenters")]
        Task<ApiResponse<List<GetCentersResponse>>> GetAllCenters();
    }
}
