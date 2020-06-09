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
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly IToDoManager _toDos;

        public ToDoController(IToDoManager toDos)
        {
           this._toDos = toDos;
        }

        // GET: api/<ToDoController>
        //This gets all To-Dos
        [HttpGet]
        public async Task <IEnumerable<ToDo>> GetAllToDos()
        {
            return await _toDos.GetAllToDos();
        }

        // GET: ToDoController/Details/5
        //This is an individual to-do
        [HttpGet("{id}")]
        public async Task<ToDo> DetailsForToDo(int id)
        {
            return await _toDos.GetToDo(id);
        }

        // POST: ToDoController/Create or Save New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ToDo>> CreateNewToDo(ToDo toDo)
        {
            await _toDos.CreateToDo(toDo);
            return CreatedAtAction("GetToDo", new { id = toDo.Id }, toDo);
        }

        // GET: ToDoController/Edit/5
        //PUT: UPDATE
        public async Task<IActionResult> UpdateToDo(int id, ToDo toDo)
        {
            if(id != toDo.Id)
            {
                return BadRequest();
            }
            bool updatedToDo = await _toDos.UpdateToDo(id, toDo);
            if (!updatedToDo)
            {
                return NotFound();
            }
            return NoContent();

        }

        // POST: ToDoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
