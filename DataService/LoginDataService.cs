using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataServiceInterface;
using Database;
using Dapper;

namespace DataService
{
    public class LoginDataService:ILoginDataService
    {
        DbService _db = new DbService();

        //String builder is faster than string.format. string.format internally call stringbuilder. 

        public UserLoginInfoResponse UserLoginInfo(LoginRequest objRequest)
        {
            #region Get Data from db using store procedure 
            //string strCommand = string.Format("call pr_get_user_info('{0}','{1}','{2}')", objRequest.UserName, objRequest.Password, objRequest.StrUDID);
            //return _db.GetDataTable(strCommand, new UserLoginInfoResponse()).FirstOrDefault();
            #endregion Get Data from db

            #region   Get static data
            UserLoginInfoResponse userData = new UserLoginInfoResponse();
            userData.SRNO = 1;
            userData.Firstname = "Joseph";
            userData.Lastname = "Chirshian";
            return userData;
            #endregion
        }
        public List<EmployeeMaster> GetEmployeeList(int userId)
        {
            #region Get data from db using store procedure
            //StringBuilder query = new StringBuilder();
            //query.Append("call pr_Get_employees(");
            //query.Append(userId);
            //query.Append(")");

            //List<EmployeeMaster> lstResponse = new List<EmployeeMaster>();

            //#region ADO
            ////DataTable dtList = Ado.GetDataTable(query.ToString());            
            ////foreach (DataRow dr in dtList.Rows)
            ////{
            ////    EmployeeMaster objResponse = new EmployeeMaster();
            ////    objResponse.FName = Convert.ToString(dr["fname"]);
            ////    objResponse.LName = Convert.ToString(dr["lname"]);
            ////    lstResponse.Add(objResponse);
            ////}
            //#endregion

            //#region Entity Framework
            ////lstResponse= _db.GetDataTable<EmployeeMaster>(query.ToString(),new EmployeeMaster()).ToList();
            //#endregion

            //#region Dapper
            //using (IDbConnection db = DapperClass.Connection())
            //{
            //    lstResponse = db.Query<EmployeeMaster>(query.ToString()).ToList();
            //}
            //#endregion
            #endregion
            List<EmployeeMaster> lstResponse = new List<EmployeeMaster>()
            {
               new EmployeeMaster(){FName="Josheph", LName="Chirstin" },
               new EmployeeMaster(){FName="John", LName="Loard" }
            };
            return lstResponse;
        }
    }
}
