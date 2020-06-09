using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_Do.Models;
using To_Do.Models.Interfaces;

namespace To_Do.Controllers
{

    public class HomeController : Controller
    {
        private readonly IToDoManager _toDoManager;

        public HomeController(IToDoManager toDoManager)
        {
            _toDoManager = toDoManager;
        }
        public IActionResult Index()
        {
         
            return View();
        }

        

    }
}
