﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itmytask.Domain.Enum;

namespace Itmytask.Domain.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
    }
}
