using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompuMedia.IRepository;
using CompuMedia.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CompuMedia.Controllers
{
    public class UserController : Controller
    {

        public IUserRepository _IUserRepository;
        public UserController(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Data = _IUserRepository.GetUsrers();
            return View();
        }
        [HttpPost]
        public IActionResult Save(UserViewModel UserViewModel)
        {
            return Json(_IUserRepository.Save(UserViewModel));
        }


        [HttpPost]
        public IActionResult Delete(string Email)
        {
            return Json(_IUserRepository.Delete(Email));
        }
    }
}
