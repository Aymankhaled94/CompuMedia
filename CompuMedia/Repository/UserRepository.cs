using CompuMedia.IRepository;
using CompuMedia.Models;
using CompuMedia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompuMedia.Repository
{
    public class UserRepository: IUserRepository
    {

        ApplicationContext _ApplicationContext;
        public UserRepository(ApplicationContext ApplicationContext)
        {
            _ApplicationContext = ApplicationContext;
        }

        public int Save(UserViewModel UserViewModel)
        {
            try
            {
                if (UserViewModel.FormType == 1)
                {
                    User user = new User();
                    user.Name = UserViewModel.Name;
                    user.Password = UserViewModel.Password;
                    user.Email = UserViewModel.Email;
                    _ApplicationContext.Users.Add(user);
                    _ApplicationContext.SaveChanges();
                }
                else
                {
                    var User = _ApplicationContext.Users.Where(c => c.Email == UserViewModel.Email).FirstOrDefault();
                    User.Name = UserViewModel.Name;
                    User.Password = UserViewModel.Password;
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

        public int Delete(string Email)
        {
            try
            {
                _ApplicationContext.Remove(_ApplicationContext.Users.Where(c => c.Email == Email).FirstOrDefault());
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
