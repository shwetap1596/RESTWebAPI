using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BusinessModel
{
    public class UserLoginInfoBOResponse
    {
        public string userName { get; set; }
        public string email { get; set; }
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string active { get; set; }
        public string birthDate { get; set; }        
        
        public static UserLoginInfoBOResponse Create(UserLoginInfoResponse objRes)
        {
            UserLoginInfoBOResponse objBORes = new UserLoginInfoBOResponse();
            if (objRes != null)
            {
                objBORes.email = objRes.Email;
                objBORes.userId = objRes.SRNO;
                objBORes.lastName = objRes.Lastname;
                objBORes.firstName = objRes.Firstname;
                objBORes.address = objRes.Address;
                objBORes.birthDate = objRes.BDate == null || objRes.BDate == "" ? string.Empty : Convert.ToDateTime(objRes.BDate).ToString("MM/dd/yyyy");
                objBORes.active = objRes.Active;
            }
            return objBORes;

        }
    }
}
