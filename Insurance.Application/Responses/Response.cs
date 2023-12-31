﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Responses
{
    public class Response<T> : Base
    {

        public List<T>? ResultList { get; set; }
        public T? ResultObject { get; set; }
        public int Total { get; set; }

        public Response()
        {
            Message = "Información procesada correctamente";
            Status = 200;
            Result = true;
        }
    }
}
