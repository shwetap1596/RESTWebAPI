using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class BOResponseSingle<T>
    {
        public int Code { get; set; }
        public string Desc { get; set; }
        public T Data { get; set; }
    }
}
