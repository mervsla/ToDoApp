using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.DTO;
using ToDo.Core.Managers;

namespace ToDo.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ToDoServiceController : Controller
    {
        IToDoManager toDoManager;
        public ToDoServiceController(IToDoManager _toDoManager)
        {
            toDoManager = _toDoManager;

        }
        [HttpGet]
        public List<ToDoDto> getAllToDos()
        {
            List<ToDoDto> todos = toDoManager.getAllToDos();
            return todos;
        }

        [HttpPost]
        public ToDoDto GetToDoInfo(ToDoDto toDoDto)
        {
            ToDoDto todo = toDoManager.GetToDoById(toDoDto.Id);
            return todo;
        }

        [HttpPost]
        public IActionResult AddToDo(ToDoDto todoDto)
        {
           
            toDoManager.AddToDo(todoDto);
            return Ok(true); ;

        }
        [HttpPost]
        public IActionResult UpdateToDo(ToDoDto todoDto)
        {
            toDoManager.UpdateToDo(todoDto);
            return Ok(true); ;
        }

        [HttpDelete]
        public IActionResult DeleteToDo(ToDoDto todoDto)
        {
            toDoManager.DeleteToDo(todoDto.Id);
            return Ok(true);
        }
    }
}
