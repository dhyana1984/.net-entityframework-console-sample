﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Model
{
    public class Error
    {
        public int ErrorId { get; set; }

        public string Query{ get; set; }

        public string Parameters { get; set; }

        public string CommandType { get; set; }

        public decimal TotalSeconds { get; set; }

        public string Exception { get; set; }

        public string InnerException { get; set; }

        public int RequireId { get; set; }

        public string FileName { get; set; }

        public DateTime CreateDate  { get; set; }

        public bool Active { get; set; }
    }
}
