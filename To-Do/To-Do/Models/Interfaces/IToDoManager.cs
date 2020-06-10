using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do.Models.DTOs;


namespace To_Do.Models.Interfaces

{
   public interface IToDoManager
    {
        //Create
        Task CreateToDo(ToDos toDo);

        //Read
        Task<ToDoDTO> GetToDo(int id);
        Task<IEnumerable<ToDos>> GetAllToDos();

        //Update
        Task<ToDos> UpdateToDo(ToDos todo, int id);
      

        //Delete
        Task<ToDos> DeleteToDo(int id);
        Task<IEnumerable<ToDos>> GetAllMyPosts(string userId);
    }
}
