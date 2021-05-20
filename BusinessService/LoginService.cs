using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using DataModel;
using BusinessServiceInterface;
using DataServiceInterface;

namespace BusinessService
{
    public class LoginService : ILoginService
    {
        #region Dependencies
        public ILoginDataService _loginDataService { get; set; }
        #endregion

        #region  Constructor
        public LoginService(ILoginDataService loginDataService)
        {
            _loginDataService = loginDataService;
        }
        #endregion

        public UserLoginInfoBOResponse UserLoginInfo(LoginBORequest objBORequest)
        {
            var objRequest = LoginBORequest.Create(objBORequest);
            var objResponse = _loginDataService.UserLoginInfo(objRequest);
            return UserLoginInfoBOResponse.Create(objResponse);

        }

        public BOResponse<EmployeeListBOResponse> GetEmployeeList(int userId)
        {
            List<EmployeeMaster> objResponse = _loginDataService.GetEmployeeList(userId);
            return EmployeeListBOResponse.Create(objResponse);
        }

    }
}
