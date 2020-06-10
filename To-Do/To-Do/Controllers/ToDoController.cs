using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        // set claim type
        public object ClaimType { get; private set; }

        public ToDoController(IToDoManager toDos)
        {
           this._toDos = toDos;
        }
        // Get all general to-dos
        // GET: api/<PostsController>
        [HttpGet]
        public async Task<IEnumerable<ToDos>> GetAllToDos()
        {
            return await _toDos.GetAllToDos();
        }

            // GET: api/<ToDoController>
            //This gets all To-Dos
            [HttpGet("MyToDos")]
        [Authorize]
        public async Task <IEnumerable<ToDos>> GetAllMyToDos()
        {
            return await _toDos.GetAllToDos();
        }

        // GET: ToDoController/Details/5
        //This is an individual to-do
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDos>> DetailsForToDo(int id)
        {
            var result = await _toDos.GetToDo(id);
            if(result == null)
            {
                return NotFound();
            }
            return result;
        }

        // POST: ToDoController/Create or Save New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ToDos>> CreateNewToDo(ToDos toDo)
        {



            await _toDos.CreateToDo(toDo);
            return CreatedAtAction("GetToDo", new { id = toDo.Id }, toDo);
        }

        // GET: ToDoController/Edit/5
        //PUT: UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo(int id,[FromBody] ToDos toDo)
        {
            if (id != toDo.Id)
            {
                return BadRequest();
            }
            await _toDos.UpdateToDo(toDo, id);
            return Ok("Complete");

        }
       
  
        // Deletion by To Do Id
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult<ToDos>> DeleteToDo(int id)
        {
            var toDo = await _toDos.DeleteToDo(id);
            if(toDo == null)
            {
                return NotFound();
            }
            return toDo;
            
        }
    }
}
