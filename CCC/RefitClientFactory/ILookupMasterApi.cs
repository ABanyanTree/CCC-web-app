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
    interface ILookupMasterApi
    {
        [Get(path: "/api/lookupmaster/getlookupbytype")]
        Task<ApiResponse<List<GetLookupResponse>>> GetLookupData(string lookupType);
    }
}
