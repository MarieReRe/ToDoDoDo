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
        public async Task<IActionResult> Index()
        {
            var toDoList = await _toDoManager.ListAsync();
            var model = toDoList.Select(toDoItem => new ToDo()
            {
                Id = toDoItem.Id,
                Title = toDoItem.Title,
                ExpectedCompletion = toDoItem.ExpectedCompletion,
                Assignee = toDoItem.Assignee,
                Difficulty = toDoItem.Difficulty
            });
            return View(model);
        }
    }
}
