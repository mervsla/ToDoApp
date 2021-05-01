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
        public bool AddToDo(ToDoDto todoDto)
        {
           
            toDoManager.AddToDo(todoDto);
            return true;

        }
        [HttpPost]
        public bool UpdateToDo(ToDoDto todoDto)
        {
            toDoManager.UpdateToDo(todoDto);
            return true;
        }

        [HttpDelete]
        public IActionResult DeleteToDo(ToDoDto todoDto)
        {
            toDoManager.DeleteToDo(todoDto.Id);
            return Ok(true);
        }
    }
}
