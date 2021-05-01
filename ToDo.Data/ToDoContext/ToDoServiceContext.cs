using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data.Entity;

namespace ToDo.Data.ToDoContext
{
   public class ToDoServiceContext:DbContext
    {
      


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=MERVE\SQLEXPRESS; initial catalog=ToDoDb; integrated security = true;");
        }
       
        public DbSet<ToDoEntity> ToDos { get; set; }

    }
}
