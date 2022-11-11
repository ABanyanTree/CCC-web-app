using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.Controllers
{
    public class CenterMasterController : Controller
    {
        public async Task<ActionResult> ManageCenter()
        {
            return View();
        }
    }
}
