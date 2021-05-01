using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Data.Entity;
using ToDo.Data.ToDoContext;

namespace ToDo.Data.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private ToDoServiceContext _context;
        private DbSet<ToDoEntity> _dbSet;

        public ToDoRepository(ToDoServiceContext context) 
        {
            _context = context;
            _dbSet = _context.Set<ToDoEntity>();
        }

        public void AddToDo(ToDoEntity todo)
        {
            _context.ToDos.Add(todo);
            _context.SaveChanges();
        }

        public void DeleteToDo(ToDoEntity todo)
        {
            _context.ToDos.Remove(todo);
            _context.SaveChanges();
        }

        public List<ToDoEntity> getAllToDos()
        {
            return _context.ToDos.ToList();
        }

        public ToDoEntity getToDoById(int id)
        {
            return _context.ToDos.Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateToDo(ToDoEntity todo)
        {
            _context.ToDos.Update(todo);
            _context.SaveChanges();
        }
    }
}
