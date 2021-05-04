using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.DTO;
using ToDo.Data.Entity;
using ToDo.Data.Repositories;
using ToDo.Data.ToDoContext;

namespace ToDo.Core.Managers
{
    public class ToDoManager : IToDoManager
    {

        ToDoRepository toDoRepository = new ToDoRepository(new ToDoServiceContext());


        public void AddToDo(ToDoDto todoDto)
        {
            todoDto.DateOfCreate = DateTime.Now;
            ToDoEntity todo = ConvertToEntity(todoDto);
            toDoRepository.AddToDo(todo);
        }



        public void DeleteToDo(int id)
        {
            ToDoEntity todo = toDoRepository.getToDoById(id);
            toDoRepository.DeleteToDo(todo);
        }
        
        public ToDoDto GetToDoById(int id)
        {
            ToDoEntity todo = toDoRepository.getToDoById(id);
            return ConvertToDto(todo);
        }
        public List<ToDoDto> getAllToDos()
        {
            List<ToDoEntity> todos = toDoRepository.getAllToDos();

            List<ToDoDto> todoDtos = new List<ToDoDto>();

            foreach (ToDoEntity todo in todos)
            {
                todoDtos.Add(ConvertToDto(todo));
            }

            return todoDtos;
        }

        public void UpdateToDo(ToDoDto todoDto)
        {
            ToDoEntity todo = toDoRepository.getToDoById(todoDto.Id);
            todo.UpdatedDate = DateTime.Now;
            todo.Description = todoDto.Description;
            toDoRepository.UpdateToDo(todo);


        }

        private ToDoEntity ConvertToEntity(ToDoDto todoDto)
        {
            ToDoEntity todo = new ToDoEntity();
            todo.Id = todoDto.Id;
            todo.Description = todoDto.Description;
            todo.CreatedDate = todoDto.DateOfCreate;

            return todo;
        }

        private ToDoDto ConvertToDto(ToDoEntity todo)
        {
            ToDoDto todoDto = new ToDoDto();
            todoDto.Id = todo.Id;
            todoDto.Description = todo.Description;
            todoDto.CreatedDate = todo.CreatedDate.ToString();
            if (todo.UpdatedDate != null)
            {
                todoDto.UpdatedDate = todo.UpdatedDate.ToString();
            }

            return todoDto;

        }
    }
}
