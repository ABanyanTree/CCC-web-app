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
    public class LookupMasterController : Controller
    {
        public async Task<ActionResult> ManageLookup()
        {
            LookupMasterRequest obj = new LookupMasterRequest();
            return View(obj);
        }






        //public async Task<IActionResult> AddMedicalNotesQuick()
        //{
        //    look model = new VanMasterRequest();
        //    return PartialView("_AddVanQuick", model);
        //}
        

    }
}
