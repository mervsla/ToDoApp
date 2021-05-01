using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data.Entity;

namespace ToDo.Data.Repositories
{
   public interface IToDoRepository
    {
        void AddToDo(ToDoEntity todo);
        ToDoEntity getToDoById(int id);
        void DeleteToDo(ToDoEntity todo);
        List<ToDoEntity> getAllToDos();
        void UpdateToDo(ToDoEntity todo);
    }
}
