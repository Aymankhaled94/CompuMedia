using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompuMedia.IRepository;
using CompuMedia.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CompuMedia.Controllers
{
    public class LoginController : Controller
    {
        public ILoginRepository _ILoginRepository;
        public IUserRepository _IUserRepository;
        public LoginController(ILoginRepository ILoginRepository, IUserRepository IUserRepository)
        {
            _ILoginRepository = ILoginRepository;

            _IUserRepository = IUserRepository;
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public int Login(LoginViewModel LoginViewModel)
        {
            return _ILoginRepository.Login(LoginViewModel);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public int Register(UserViewModel UserViewModel)
        {
            return _IUserRepository.Save(UserViewModel);
        }

    }
}
