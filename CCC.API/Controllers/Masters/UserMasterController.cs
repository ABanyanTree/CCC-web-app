﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.API.Controllers.Masters
{
    public class UserMasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}