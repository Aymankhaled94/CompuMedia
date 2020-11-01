using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CompuMedia.ViewModel
{
    public class ToDoViewModel
    {

        public int FormType { get; set; }
        [Required(ErrorMessage ="*")]
        public string Title { get; set; }
        [Required(ErrorMessage = "*")]
        public string Action { get; set; }
        [Required(ErrorMessage = "*")]
        public DateTime DueTime { get; set; }
        [Required(ErrorMessage = "*")]
        public int UserId { get; set; }
    }
}
