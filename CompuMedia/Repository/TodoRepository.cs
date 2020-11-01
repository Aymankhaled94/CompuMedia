using CompuMedia.IRepository;
using CompuMedia.Models;
using CompuMedia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompuMedia.Repository
{
    public class TodoRepository: ITodoRepository
    {
        ApplicationContext _ApplicationContext;
        public TodoRepository(ApplicationContext ApplicationContext)
        {
            _ApplicationContext = ApplicationContext;
        }

        public int Save(ToDoViewModel ToDoViewModel)
        {
            try
            {
                if (ToDoViewModel.FormType == 1)
                {
                    Todo Todo = new Todo();
                    Todo.Title = ToDoViewModel.Title;
                    Todo.Action = ToDoViewModel.Action;
                    Todo.UserId = ToDoViewModel.UserId;
                    Todo.DueTime = ToDoViewModel.DueTime;
                    _ApplicationContext.Todos.Add(Todo);
                    _ApplicationContext.SaveChanges();
                }
                else
                {
                    var Todo = _ApplicationContext.Todos.Where(c => c.Title == ToDoViewModel.Title).FirstOrDefault();
                    Todo.UserId = ToDoViewModel.UserId;
                    Todo.Action = ToDoViewModel.Action;
                    Todo.DueTime = ToDoViewModel.DueTime;
                    _ApplicationContext.SaveChanges();
                }
                return 1;
            }
            catch
            {

                return -1;
            }
        }

        public List<User> GetUsrers()
        {
            return _ApplicationContext.Users.ToList();
        }


        public List<Todo> GetTodos()
        {
            return _ApplicationContext.Todos.ToList();
        }

        public int Delete(string Title)
        {
            try
            {
                _ApplicationContext.Remove(_ApplicationContext.Todos.Where(c => c.Title == Title).FirstOrDefault());
                _ApplicationContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

    }
}
