
using BusinessModel;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RestWebAPI.Filters
{
    public class JwtAuthenticationAttribute : AuthorizationFilterAttribute 
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            var request = actionContext.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme.ToLower() != "bearer")
                return;

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                   new BOResponseSingle<string>
                   {
                       Code = -3,
                       Desc = "Missing Jwt Token",
                       Data = null
                   }
                   );
                return;
            }

            var token = authorization.Parameter;
            var valid = Controllers.TokenController.ValidateToken(token);

            if (valid)
            {
                //Thread.CurrentPrincipal is the way .NET applications represent the identity of the use
                //It can hold one or more identities and allows the application to check if the principal is in a role through the IsInRole method.
                //When user authenticated successfully, we set currentprinciple and it will set at every request so that in every request you can check
                //like Thread.CurrentPrincipal.Identity.IsAuthenticated if it's true then user is authenticated and false then user is not authenticated
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(token), null);
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    new BOResponseSingle<string>
                    {
                        Code = -3,
                        Desc = "Invalid token",
                        Data = null
                    }
                    );
            }
        }
    }
}