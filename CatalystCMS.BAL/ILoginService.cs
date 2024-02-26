using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CatalystCMS.BAL
{
    public interface ILoginService
    {
        bool ValidateUser(string Username, string Password);
    }
}
