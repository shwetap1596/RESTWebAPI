using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace DataService
{
    public class DbService
    {
        Context _db = new Context();

        public List<T> GetDataTable<T>(string sqlQuery, T responseObj)
        {
            List<T> dbresult = _db.Database.SqlQuery<T>(sqlQuery).ToList();
            return dbresult;
        }
    }
}
