using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CompuMedia.ViewModel
{
    public class UserViewModel
    {
        public int FormType { get; set; }
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage ="Correct Email Please")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
