using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalystCMS.DAL
{
    public interface IUserDetailsRepo
    {
        bool ValidateUser(string Username, string Password);
    }
}
