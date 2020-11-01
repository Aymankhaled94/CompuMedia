using CompuMedia.IRepository;
using CompuMedia.Models;
using CompuMedia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompuMedia.Repository
{
    public class LoginRepository : ILoginRepository
    {

        ApplicationContext _ApplicationContext;
        public LoginRepository(ApplicationContext ApplicationContext)
        {
            _ApplicationContext = ApplicationContext;
        }

        public int Login(LoginViewModel LoginViewModel)
        {

            if (_ApplicationContext.Users.Where(c=>c.Email== LoginViewModel.Email && c.Password== LoginViewModel.Password).FirstOrDefault()!=null)
            {
                return 1;
            }
            return 0;
        }
    }
}
