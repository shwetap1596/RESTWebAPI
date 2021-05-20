using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;

namespace BusinessServiceInterface
{
    public interface ILoginService
    {
        UserLoginInfoBOResponse UserLoginInfo(LoginBORequest objBORequest);
        BOResponse<EmployeeListBOResponse> GetEmployeeList(int userId);
    }
}
