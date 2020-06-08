using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Model.Services
{
    public class ToDoService : IToDoManager
    {
        public Task CreateToDo(ToDo toDo)
        {
            throw new NotImplementedException();
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
