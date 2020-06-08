using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do.Data;
using To_Do.Models;

namespace To_Do.Models.Services
{
    public class ToDoService : IToDoManager
    {
        private ToDoDbContext _context;

        public ToDoService(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task CreateToDo(ToDo toDo)
        {
            _context.Entry(toDo).State = EntityState.Added;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteToDo(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            _context.Entry(todo).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDo>> GetAllToDos()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDo> GetToDo(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            return todo;
        }

        public async Task<ToDo> UpdateToDo(ToDo todo, int id)
        {
            if (todo.Id == id)
            {
                _context.Entry(todo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return todo;
        }
    }
    }
}
