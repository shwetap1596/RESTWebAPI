using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataServiceInterface
{
    public interface ILoginDataService
    {
        UserLoginInfoResponse UserLoginInfo(LoginRequest objRequest);
        List<EmployeeMaster> GetEmployeeList(int userId);
    }
}
