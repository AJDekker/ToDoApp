using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Models
{
    public class Sprint
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int StoryPoints { get; set; }
    }
}
