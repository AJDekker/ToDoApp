using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StoryPoints { get; set; }
        public DateTime Due { get; set; } 
        public Guid SprintId { get; set; }
        public Sprint Sprint { get; set; }
    }
}
