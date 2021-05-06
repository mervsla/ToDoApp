using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Core.DTO
{
   public class ToDoDto
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public DateTime DateOfCreate { get; set; }
        public DateTime DateOfUpdate { get; set; }

        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string TimetoFinish { get; set; }
        public bool IsCompleted { get; set; }
    }
}
