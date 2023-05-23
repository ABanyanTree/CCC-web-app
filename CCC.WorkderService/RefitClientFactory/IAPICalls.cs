using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CCC.WorkderService.RefitClientFactory
{
    public interface IAPICalls
    {
        [Get(path: "/api/hostedservice/vetreportnotification")]
        Task<HttpResponseMessage> VetReportNotification([Header("ApiKey")] string authorization);

        [Get(path: "/api/hostedservice/centerreportnotification")]
        Task<HttpResponseMessage> CenterReportNotification([Header("ApiKey")] string authorization);
    }
}
