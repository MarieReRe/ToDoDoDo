using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do.Data;
using To_Do.Models;
using To_Do.Models.DTOs;
using To_Do.Models.Interfaces;

namespace To_Do.Models.Services
{
    public class ToDoService : IToDoManager
    {
        private ToDoDbContext _context;

        public ToDoService(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task CreateToDo(ToDos toDo)
        {
            _context.Entry(toDo).State = EntityState.Added;
            await _context.SaveChangesAsync();

        }

        public async Task<ToDos> DeleteToDo(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            _context.Entry(todo).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<IEnumerable<ToDos>> GetAllMyPosts(string userId)
        {
            return await _context.ToDos
                .Where (toDo => toDo.CreatedByUserId != null && toDo.CreatedByUserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ToDos>> GetAllToDos()
        {
            return await _context.ToDos.ToListAsync();
        }

        //Used for First Mock Test
        public async Task<ToDos> GetToDo(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            return todo;
        }

       

        public async Task<ToDos> UpdateToDo(ToDos todo, int id)
        {
            if (todo.Id == id)
            {
                _context.Entry(todo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return todo;
        }

      

        Task<ToDoDTO> IToDoManager.GetToDo(int id)
        {
            throw new NotImplementedException();
        }
    }

}
