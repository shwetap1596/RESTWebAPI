using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BusinessModel
{
    public class EmployeeListBOResponse
    {
        #region Declaration
        public string fName { get; set; }
        public string lName { get; set; }
        public string department { get; set; }
        public int globalUserID { get; set; }
        public int userID { get; set; }
        public string chatLanguage { get; set; }
        public string userName { get; set; }
        public string alias { get; set; }
        public int isInternal { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string phone2 { get; set; }
        public string email { get; set; }
        public string fax { get; set; }
        public string groupType { get; set; }
        public int isFavorite { get; set; }
        public int isAdmin { get; set; }
        #endregion


        #region User Defined Methods
        public static BOResponse<EmployeeListBOResponse> Create(List<EmployeeMaster> lstResponse)
        {
            List<EmployeeListBOResponse> lstBOResponse = new List<EmployeeListBOResponse>();
            if (lstResponse.Any())
            {
                foreach (EmployeeMaster objResponse in lstResponse)
                {
                    EmployeeListBOResponse objBOResponse = new EmployeeListBOResponse();
                    objBOResponse.fName = objResponse.FName;
                    objBOResponse.lName = objResponse.LName;
                    objBOResponse.department = objResponse.Department;
                    objBOResponse.userID = objResponse.UserId;
                    objBOResponse.userName = objResponse.UserName;
                    objBOResponse.email = objResponse.Email;
                    objBOResponse.fax = objResponse.Fax;
                    objBOResponse.isFavorite = objResponse.IsFavorite;
                        

                    lstBOResponse.Add(objBOResponse);
                }
                return new BOResponse<EmployeeListBOResponse>()
                {
                    Code = 0,
                    Desc = "",
                    Data = lstBOResponse

                };
            }
            else
            {
                return new BOResponse<EmployeeListBOResponse>()
                {
                    Code = 0,
                    Desc = "",
                    Data = null

                };
            }
        }
        #endregion
    }
}
