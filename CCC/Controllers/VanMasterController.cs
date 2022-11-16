using CCC.UI.RefitClientFactory;
using CCC.UI.Utility;
using CCC.UI.ViewModels;
using DataTables.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CCC.UI.Controllers
{
    public class VanMasterController : Controller
    {
        public async Task<ActionResult> ManageVan()
        {
            VanMasterRequest obj = new VanMasterRequest();
            return View(obj);
        }
    }
}
