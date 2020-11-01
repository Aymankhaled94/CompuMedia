using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompuMedia.IRepository;
using CompuMedia.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CompuMedia.Controllers
{
    public class TodoController : Controller
    {
        public ITodoRepository _ITodoRepository;
        public TodoController(ITodoRepository ITodoRepository)
        {
            _ITodoRepository = ITodoRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Data = _ITodoRepository.GetTodos();
            ViewBag.Users = _ITodoRepository.GetUsrers();
            return View();
        }

        [HttpPost]
        public IActionResult Save(ToDoViewModel ToDoViewModel)
        {
            return Json(_ITodoRepository.Save(ToDoViewModel));
        }


        [HttpPost]
        public IActionResult Delete(string Title)
        {
            return Json(_ITodoRepository.Delete(Title));
        }

    }
}
