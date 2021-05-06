using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data.Entity;

namespace ToDo.Data.ToDoContext
{
   public class ToDoServiceContext:DbContext
    {



        public DbSet<ToDoEntity> ToDos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ToDoAppDb;Integrated Security=true; User Id=postgres;Password=0010;");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoEntity>().ToTable("ToDoEntity", "public");
        }

    }
}
