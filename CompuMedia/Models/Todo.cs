using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompuMedia.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public DateTime DueTime { get; set; }
        public int UserId { get; set; }


    }
}
