using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class EmployeeMaster
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Department { get; set; }
        public int UserId { get; set; }
        public int CompanyUserId { get; set; }
        public string Language { get; set; }
        public string UserName { get; set; }
        public string Alias { get; set; }
        public int IsInternal { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string GroupType { get; set; }
        public int IsFavorite { get; set; }
    }
}
