using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using FluentValidation;
using FluentValidation.Attributes;

namespace BusinessModel
{
    [Validator(typeof(LoginValidator))]
    public class LoginBORequest
    {
        #region Declaration

        #region DataAnnotation Validation
        //[Required]
        //public string username { get; set; }
        //[Required]
        //public string password { get; set; }
        //[Required]
        //public string udId { get; set; }
        #endregion

        #region Fluent Validation
        public string username { get; set; }
        public string password { get; set; }
        public string udId { get; set; }
        #endregion


        #endregion

        #region User Defined Method Mapper
        /// <summary>
        /// Mapper to map BusinessRequest object to DataRequest object.
        /// </summary>
        /// <param name="objBORequest">BusinessObject LoginRequest</param>
        public static LoginRequest Create(LoginBORequest objBORequest)
        {
            LoginRequest objRequest = new LoginRequest();
            objRequest.UserName = objBORequest.username;
            objRequest.Password = objBORequest.password;
            objRequest.StrUDID = objBORequest.udId;           
            return objRequest;
        }
        #endregion
    }
    public class LoginValidator : AbstractValidator<LoginBORequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.username).NotEmpty().WithMessage("UserName cannot be empty");
            RuleFor(x => x.password).NotEmpty().WithMessage("Password cannot be empty");

        }
    }
}
