using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace To_Do.Models
{
    public class ToDos
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime? ExpectedCompletion { get; set; }

        public string Assignee {get;set;} 

        public int Difficulty { get; set; }

       
    }
}
