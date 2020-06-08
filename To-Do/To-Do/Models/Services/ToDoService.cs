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

        public Task DeleteToDo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDo>> GetAllToDos()
        {
            throw new NotImplementedException();
        }

        public Task<ToDo> GetToDo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ToDo> UpdateToDo(ToDo todo, int id)
        {
            throw new NotImplementedException();
        }
    }
}
