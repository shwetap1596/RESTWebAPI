﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class BOResponse<T>
    {
        public int Code { get; set; }
        public string Desc { get; set; }
        public List<T> Data {get;set;}
    }
}
