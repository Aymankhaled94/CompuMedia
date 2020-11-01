using CompuMedia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompuMedia.IRepository
{
     public interface ILoginRepository
    {
        public int Login(LoginViewModel LoginViewModel);
    }
}
