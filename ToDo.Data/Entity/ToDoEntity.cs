using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Data.Entity

{
   public class ToDoEntity
    {
        public int Id { get; set; }
        public string Description{ get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime TimetoFinish { get; set; }
        public bool IsCompleted { get; set; }

    }
}
