using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Models.DTOs
{
    public class ToDoDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime? ExpectedCompletion { get; set; }

        public string Assignee { get; set; }

        public int Difficulty { get; set; }
    }
}
