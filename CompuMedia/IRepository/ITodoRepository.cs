using CompuMedia.Models;
using CompuMedia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompuMedia.IRepository
{
    public interface ITodoRepository
    {

        public int Save(ToDoViewModel ToDoViewModel);
        public List<User> GetUsrers();
        public List<Todo> GetTodos();
        public int Delete(string Title);
    }
}
