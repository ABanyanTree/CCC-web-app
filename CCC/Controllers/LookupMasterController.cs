using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        //public async Task<IActionResult> AddMedicalNotesQuick()
        //{
        //    look model = new VanMasterRequest();
        //    return PartialView("_AddVanQuick", model);
        //}
        

    }
}
