using CompuMedia.Models;
using CompuMedia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompuMedia.IRepository
{
    public interface IUserRepository
    {
        public int Save(UserViewModel UserViewModel);
        public List<User> GetUsrers();
        public int Delete(string Email);
    }
}
