using CatalystCMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalystCMS.BAL
{
    public class LoginService : ILoginService
    {
        public readonly IUserDetailsRepo _userDetailsRepo;

        public LoginService(IUserDetailsRepo userDetailsRepo)
        {
            _userDetailsRepo = userDetailsRepo;
        }
        public bool ValidateUser(string Username, string Password)
        {
            var result = _userDetailsRepo.ValidateUser(Username, Password);
            return result;
        }
    }
}
