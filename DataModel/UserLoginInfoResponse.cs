using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class UserLoginInfoResponse
    {
        #region Properties        
        public string Email { get; set; }
        public int SRNO { get; set; }        
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Address { get; set; }
        public string BDate { get; set; }        
        public string Active { get; set; }
        #endregion
    }
}
