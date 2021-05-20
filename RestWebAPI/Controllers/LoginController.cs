using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using BusinessModel;
using BusinessServiceInterface;
using RestWebAPI.Filters;

namespace RestWebAPI.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        #region Dependencies
        public ILoginService _loginService { get; set; }
        #endregion

        #region  Constructor
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        #endregion

        [Route("UserLogin")]
        [HttpGet]
        public HttpResponseMessage UserLogin([FromBody] LoginBORequest objBORequest)
        {
            //if (ModelState.IsValid)
            //{
                UserLoginInfoBOResponse objBOResponse = _loginService.UserLoginInfo(objBORequest);
                if (objBOResponse.userId != 0)
                {
                    //If get user then implement JWT token.
                    string access_token=TokenController.GenerateToken(objBOResponse.firstName,2);

                    return Request.CreateResponse(HttpStatusCode.OK, access_token);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            //}
            //return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
        }

        [Route("GetEmployeeList")]
        [JwtAuthentication]
        [HttpGet]
        public IHttpActionResult GetEmployeeList()
        {
            var objBOResponse = _loginService.GetEmployeeList(4893);
            return Ok(objBOResponse);
        }        

    }
}
