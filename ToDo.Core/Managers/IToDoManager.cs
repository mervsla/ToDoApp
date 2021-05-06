using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.DTO;

namespace ToDo.Core.Managers
{
   public interface IToDoManager
    {
        void AddToDo(ToDoDto todo);
        void DeleteToDo(int id);
        List<ToDoDto> getAllToDos();
        void UpdateToDo(ToDoDto todoDto);
        ToDoDto GetToDoById(int id);
        void ToDoCompleted(int id);
    }
}
