using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class LoginRequest
    {
        #region Property Declaration
        public string UserName { get; set; }        
        public string Password { get; set; }
        public string StrUDID { get; set; }        
        #endregion

    }
}
