using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.API.Controllers.Masters
{
    public class CenterMasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
